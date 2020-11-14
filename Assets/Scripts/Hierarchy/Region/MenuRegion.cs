using System;
using Hierarchy.Layer;
using Hierarchy.Menu;
using UnityEngine;
using Util;

namespace Hierarchy.Region
{
    public abstract class MenuRegion : UiRegion
    {
        [HideInInspector] public UiLayer layer;

        protected override void Awake()
        {
            base.Awake();
            
            OnLoaded += delegate(UiElement uiElement) { ((UiMenu) uiElement).layer = layer; };
        }
    }
}
