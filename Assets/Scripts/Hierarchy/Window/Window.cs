using System.Collections.Generic;
using Hierarchy.Region;
using Manager;
using UnityEngine;

namespace Hierarchy.Window
{
    public class WindowAction
    {
        public string Message { get; private set; }

        public Color DisplayColor { get; private set; } = Color.white;
        
        public delegate void Action();

        public List<Action> OnClick { get; } = new List<Action>
        {
            delegate
            {
                //default action
                if (UiManager.Instance.uiRoot.GetMenuRegion(out WindowRegion region)) region.Unload();
            }
        };

        public WindowAction(string message, Color displayColor = default, List<Action> onClick = null)
        {
            Message = message;
            
            if (displayColor != default) DisplayColor = displayColor;

            if (onClick != null) OnClick.AddRange(onClick);
        }
    }
    
    public class Window
    {
        public string Message { get; private set; }

        public Color DisplayColor { get; private set; } = Color.white;
        
        //actions for different buttons
        public List<WindowAction> WindowActions { get; private set; }
        
        public Window(string message, Color displayColor = default, List<WindowAction> windowActions = null)
        {
            Message = message;
            
            if (displayColor != default) DisplayColor = displayColor;

            WindowActions = windowActions;
        }
    }
}
