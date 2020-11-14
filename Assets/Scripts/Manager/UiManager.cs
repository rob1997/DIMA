using System;
using System.Linq;
using Hierarchy;
using Hierarchy.Alert;
using Hierarchy.Menu;
using Hierarchy.Window;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;
using Util;

namespace Manager
{
    public class UiManager : Singleton<UiManager>
    {
        [HideInInspector] public UiRoot uiRoot;

        public AlertFactory alertFactory = new AlertFactory();
        public WindowFactory windowFactory = new WindowFactory();

        private void Start()
        {
            Addressables.LoadAssetAsync<GameObject>(UiConstants.UiRootAddress)
                .Completed += response => 
            {
                if (!response.IsValid() || response.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"can't load prefab {UiConstants.UiRootAddress}");

                    return;
                }

                uiRoot = Instantiate(response.Result).GetComponent<UiRoot>();
            };
        }
    }
}
