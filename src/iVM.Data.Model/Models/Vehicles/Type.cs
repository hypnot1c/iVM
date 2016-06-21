using iVM.Data.Model;
using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class Type: BaseModel
  {
    public string Name { get; set; }
    public virtual ICollection<CategoryToType> Categories { get; set; }
    public virtual ICollection<Model> Models { get; set; }
  }
}
