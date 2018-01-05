﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataBaseContextExtensions
{
  public static class EntityTypeConfigurationExtensions
  {
    private static readonly Dictionary<Assembly, IEnumerable<Type>> typesPerAssembly = new Dictionary<Assembly, IEnumerable<Type>>();

    public static ModelBuilder UseEntityTypeConfiguration(this ModelBuilder modelBuilder, Assembly extenstionsAssembly)
    {
      if (!typesPerAssembly.TryGetValue(extenstionsAssembly, out IEnumerable<Type> configurationTypes))
      {
        typesPerAssembly[extenstionsAssembly] = configurationTypes = extenstionsAssembly
        .GetExportedTypes()
        .Where(x =>
          (x.GetTypeInfo().IsClass)
          &&
          (!x.GetTypeInfo().IsAbstract)
          &&
          (
            x.GetInterfaces()
              .Any(y =>
                  (y.GetTypeInfo().IsGenericType)
                  &&
                  (y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
              )
           )
         );
      }

      var configurations = configurationTypes.Select(x => Activator.CreateInstance(x));

      foreach (dynamic configuration in configurations)
      {
        modelBuilder.ApplyConfiguration(configuration);
      }

      return modelBuilder;
    }
  }
}