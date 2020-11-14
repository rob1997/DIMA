using Hierarchy.Menu.Alert;
using Hierarchy.Region;
using Manager;
using UnityEngine;

namespace Hierarchy.Alert
{
    public class AlertFactory
    {
        public void Create(Alert alert)
        {
            UiRoot root = UiManager.Instance.uiRoot;
            
            root.LoadMenu<AlertRegion>(typeof(AlertMenu));

            if (root.GetMenuRegion(out AlertRegion alertRegion))
            {
                alertRegion.OnLoaded += menu =>
                {
                    (menu as AlertMenu)?.Attach(alert);
                };
            }
        }
    }
}
