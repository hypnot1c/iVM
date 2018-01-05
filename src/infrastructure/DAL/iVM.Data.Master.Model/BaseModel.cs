using System;

namespace iVM.Data.Master.Model
{
  public class BaseModel
  {
    public BaseModel()
    {
      this.CorrectionDate = DateTimeOffset.UtcNow;
    }
    public int Id { get; set; }
    public DateTimeOffset CorrectionDate { get; set; }
  }
}
