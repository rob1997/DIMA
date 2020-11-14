using System.Collections.Generic;
using Hierarchy.Region;
using UnityEngine;

namespace Hierarchy.Layer
{
    public abstract class UiLayer : MonoBehaviour
    {
        [HideInInspector] public List<MenuRegion> regions;

        private void Awake()
        {
            regions = new List<MenuRegion>(GetComponentsInChildren<MenuRegion>());

            regions.ForEach(region => { region.layer = this; });
        }
    }
}