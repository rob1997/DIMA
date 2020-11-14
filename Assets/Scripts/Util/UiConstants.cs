using System;
using System.Collections.Generic;
using Hierarchy.Menu;
using Hierarchy.Menu.Alert;
using Hierarchy.Menu.Bar;
using Hierarchy.Menu.Base;
using Hierarchy.Menu.Window;
using Hierarchy.Region;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Util
{
    public static class UiConstants
    {
        public static readonly string UiRootAddress = "Assets/Prefabs/Menus/UiRoot.prefab";
        
        /// <summary>
        /// <see cref="Type"/> needs to be of type UiMenu
        /// </summary>
        private static readonly Dictionary<Type, string> MenuAddressDictionary = new Dictionary<Type, string>
        {
            //Base Layer
            
            {typeof(HomeMenu), "Assets/Prefabs/Menus/Base/HomeMenu.prefab"}
            
            //Base Region
            
            //Top Region
            
            //Bottom Region
            
            //Alert Layer

            //Window Layer
        };

        public static bool GetMenuAddress(Type menu, out string address)
        {
            address = string.Empty;

            if (!menu.IsSubclassOf(typeof(UiMenu)))
            {
                Debug.LogError($"{menu} must be of type {typeof(UiMenu)}");
                
                return false;
            }

            bool hasMenu = MenuAddressDictionary.TryGetValue(menu, out address);

            if (!hasMenu) Debug.LogError($"{menu} address not found");
            
            return hasMenu;
        }
        
        [System.Serializable]
        public struct Page
        {
            public Toggle toggle;

            public AssetReference pageAddress;
        }
    }
}
