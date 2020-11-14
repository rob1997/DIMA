using Hierarchy.Menu.Alert;
using Hierarchy.Menu.Window;
using Hierarchy.Region;
using Manager;
using UnityEngine;

namespace Hierarchy.Window
{
    public class WindowFactory
    {
        public void Create(Window window)
        {
            UiRoot root = UiManager.Instance.uiRoot;
            
            root.LoadMenu<WindowRegion>(typeof(WindowMenu));

            if (root.GetMenuRegion(out WindowRegion windowRegion))
            {
                windowRegion.OnLoaded += menu =>
                {
                    (menu as WindowMenu)?.Attach(window);
                };
            }
        }
    }
}
