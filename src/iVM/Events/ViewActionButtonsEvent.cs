using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Events
{
  public class ActionButton
  {
    public string Name { get; set; }
    public FontAwesome.UWP.FontAwesomeIcon Icon { get; set; }
    public Action OnClick { get; set; }
  }


  public class ViewActionButtonsEvent
  {
    public List<ActionButton> ActionButtons { get; set; }

    public ViewActionButtonsEvent(IEnumerable<ActionButton> actionButtons)
    {
      this.ActionButtons = actionButtons.ToList();
    }

  }
}
