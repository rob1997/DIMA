using Hierarchy.Layer;
using Hierarchy.Region;
using UnityEngine;

namespace Hierarchy.Menu
{
    public abstract class UiMenu : UiElement
    {
        [HideInInspector] public UiLayer layer;
    }
}
