using DG.Tweening;
using Hierarchy.Region;
using UnityEngine.Serialization;

namespace Transition
{
    [System.Serializable]
    public abstract class UiTransition
    {
        [FormerlySerializedAs("Duration")]
        public float duration;

        public abstract void Transition(UiRegion region, out Tween tween);
    }
}