using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.Events
{
  public class ActionButton
  {
    public FontAwesome.UWP.FontAwesomeIcon Icon { get; set; }
  }


  public class ViewActionButtonsEvent
  {
    public List<ActionButton> ActionButtons
    {
      get
      {
        return new List<ActionButton> {
          new ActionButton { Icon = FontAwesome.UWP.FontAwesomeIcon.Edit },
          new ActionButton { Icon = FontAwesome.UWP.FontAwesomeIcon.Lock }
        };
      }
    }
  }
}
