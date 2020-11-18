using System;
using Hierarchy.Region.Bar;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Hierarchy.Menu.Bar
{
    public class TopBarMenu : BarMenu
    {
        [SerializeField] private Button sideBarButton;

        private void Start()
        {
            sideBarButton.onClick.AddListener(delegate
            {
                UiManager.Instance.uiRoot.LoadMenu<SideBarRegion>(typeof(SideBarMenu));
            });
        }
    }
}
