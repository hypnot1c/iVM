using iVM.Data.Model;

namespace iVM.Vehicle.Model
{
  public class Model: BaseModel
  {
    public int BrandID { get; set; }
    public Brand Brand { get; set; }
    public int TypeID { get; set; }
    public Type Type { get; set; }
    public string Name { get; set; }
  }
}
