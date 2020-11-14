using DG.Tweening;
using Hierarchy.Region;
using UnityEngine;

namespace Transition.BiDirectional
{
    [System.Serializable]
    public class ScaleTransition : BiDirectionalTransition
    {
        public override void Transition(UiRegion region, out Tween tween)
        {
            tween = region.transform.DOScale(direction ? Vector3.one : Vector3.zero, duration);
        }
    }
}