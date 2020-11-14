using System;
using DG.Tweening;
using Hierarchy.Menu;
using Manager;
using Transition;
using Transition.BiDirectional;
using UnityEngine.AddressableAssets;

namespace Hierarchy.Region
{
    using UnityEngine;
    
    public class AlertRegion : MenuRegion
    {
        //in ScaleOut
        //out ScaleIn
        protected override UiTransition InTransition { get; set; } = new ScaleTransition{duration = .5f, direction = true};
        protected override UiTransition OutTransition { get; set; } = new ScaleTransition{duration = .5f, direction = false};
    }
}
