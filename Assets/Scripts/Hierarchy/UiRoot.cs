using System.Collections.Generic;
using Hierarchy.Layer;
using Hierarchy.Menu;
using Hierarchy.Menu.Bar;
using Hierarchy.Menu.Base;
using Hierarchy.Region;
using Hierarchy.Region.Bar;
using Hierarchy.Window;
using Manager;
using Resource.Script.Profile;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

namespace Hierarchy
{
    public class UiRoot : MonoBehaviour
    {
        [HideInInspector] public List<UiLayer> layers;

        public Transform canvas;
        
        [FormerlySerializedAs("Profile")]
        public UiProfile profile;

        private void Start()
        {
            layers = new List<UiLayer>(canvas.GetComponentsInChildren<UiLayer>());
        }

        public void LoadMenu<TRegion>(System.Type menu) where TRegion : MenuRegion
        {
            if (GetMenuRegion(out TRegion region) && UiConstants.GetMenuAddress(menu, out string address))
            {
                region.Load(address);
            }
        }

        public void UnloadMenu<TRegion>() where TRegion : MenuRegion
        {
            if (GetMenuRegion(out TRegion region))
            {
                region.Unload();
            }
        }

        public bool GetLayer<TLayer>(out UiLayer layer) where TLayer : UiLayer
        {
            layer = null;

            layer = layers.Find(l => l is TLayer);

            if (layer == null)
            {
                Debug.Log($"layer {nameof(TLayer)} not found");
            }

            return layer;
        }

        public bool GetMenuRegion<TRegion>(out TRegion region) where TRegion : MenuRegion
        {
            region = null;

            foreach (UiLayer layer in layers)
            {
                region = layer.regions.Find(r => r is TRegion) as TRegion;

                if (region != null)
                {
                    break;
                }
            }

            if (region == null)
            {
                Debug.LogError($"region {nameof(TRegion)} not found");
            }

            return region;
        }
    }
}