using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Data.Vehicle.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iVM.Core.UI.ViewModels.Vehicle
{
  public class VehicleTypeSelectViewModelBase : BaseViewModel
  {
    public VehicleTypeSelectViewModelBase(
      IEventAggregator eventAggregator,
      VehicleContext masterContext) : base(eventAggregator)
    {
      this.VehicleTypes = masterContext.VehicleTypes.Select(vt => new VehicleTypeEntity { Id = vt.Id, Name = vt.Name });
    }

    public IEnumerable<VehicleTypeEntity> VehicleTypes { get; set; }

    private string _selectedEventType;
    public string SelectedEventType
    {
      get { return this._selectedEventType; }
      set
      {
        this._selectedEventType = value;
        this.NotifyOfPropertyChange(() => this.SelectedEventType);
      }
    }
  }
}
