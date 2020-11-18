using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Hierarchy.Menu.Bar
{
    public class SideBarMenu : BarMenu
    {
        [SerializeField] private Button backdropButton;

        private void Start()
        {
            backdropButton.onClick.AddListener(delegate
            {
                region.Unload();
            });
        }
    }
}
