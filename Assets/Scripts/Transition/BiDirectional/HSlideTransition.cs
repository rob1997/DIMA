using DG.Tweening;
using Hierarchy.Region;
using UnityEngine;

namespace Transition.BiDirectional
{
    /// <summary>
    /// Vertical Slide
    /// </summary>
    [System.Serializable]
    public class HSlideTransition : BiDirectionalTransition
    {
        public bool inverse;

        public override void Transition(UiRegion region, out Tween tween)
        {
            Vector3 idlePos = region.idleLocalPosition;

            RectTransform rectT = region.transform as RectTransform;

            Debug.Assert(rectT != null, nameof(rectT) + " != null");
            
            float distance = rectT.rect.width;

            region.transform.DOComplete();

            //change in/out direction
            if (inverse)
            {
                tween = rectT.DOLocalMoveX(direction ? idlePos.x : idlePos.x - distance, duration);
            }

            else
            {
                tween = rectT.DOLocalMoveX(direction ? idlePos.x + distance : idlePos.x, duration);
            }
        }
    }
}