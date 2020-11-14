using System.Collections.Generic;
using Hierarchy.Region;
using Manager;
using UnityEngine;

namespace Hierarchy.Alert
{
    public class Alert
    {
        public string Message { get; }
        
        public float Lifetime { get; }

        public Color DisplayColor { get; }

        public bool Notification { get; }

        public delegate void Action();

        public List<Action> OnClick { get; } = new List<Action>
        {
            //default behaviour
            delegate
            {
                if (UiManager.Instance.uiRoot.GetMenuRegion(out AlertRegion region)) region.Unload();
            }
        };
        
        public Alert(string message, Color color = default, bool notification = true, float lifeTime = 0f, List<Action> onClick = null)
        {
            Message = message;
            Lifetime = lifeTime;
            DisplayColor = color == default ? Color.white : color;
            Notification = notification;
            
            if (onClick != null) OnClick.AddRange(onClick);
        }
    }
}
