using iVM.Data.Model;
using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class Category: BaseModel
  {
    public string Name { get; set; }
    public ICollection<CategoryToType> Types { get; set; }
  }
}
