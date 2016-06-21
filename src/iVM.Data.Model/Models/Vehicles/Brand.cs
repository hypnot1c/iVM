using iVM.Data.Model;
using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class Brand: BaseModel
  {
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; }
  }
}
