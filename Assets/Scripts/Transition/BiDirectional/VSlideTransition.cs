using DG.Tweening;
using Hierarchy.Region;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Transition.BiDirectional
{
    /// <summary>
    /// Vertical Slide
    /// </summary>
    [System.Serializable]
    public class VSlideTransition : BiDirectionalTransition
    {
        public bool inverse;

        public override void Transition(UiRegion region, out Tween tween)
        {
            Vector3 idlePos = region.idleLocalPosition;

            RectTransform rectT = region.transform as RectTransform;

            Debug.Assert(rectT != null, nameof(rectT) + " != null");
            
            float distance = rectT.rect.height;

            region.transform.DOComplete();

            //change in/out direction
            if (inverse)
            {
                tween = rectT.DOLocalMoveY(direction ? idlePos.y : idlePos.y - distance, duration);
            }

            else
            {
                tween = rectT.DOLocalMoveY(direction ? idlePos.y + distance : idlePos.y, duration);
            }

            //Vector3 rootPosition = new Vector3(0, (Screen.height / 2f) - (distance / 2f), 0);

            //if (transform.localPosition.y < 0)
            //{
            //    rootPosition *= -1f;
            //}

            //Vector3 endPosition = new Vector3(0, transform.localPosition.y < 0 ? rootPosition.y - distance : rootPosition.y + distance, 0);

            //tween = rectT.DOLocalMove(Direction ? rootPosition : endPosition, Duration);
        }
    }
}