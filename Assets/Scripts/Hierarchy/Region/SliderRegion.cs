using System.Collections.Generic;
using DG.Tweening;
using Transition;
using Transition.BiDirectional;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

namespace Hierarchy.Region
{
    public class SliderRegion : UiRegion
    {
        //in HSlideRight
        //out HSlideLeftInstant
        protected override UiTransition InTransition { get; set; } = new HSlideTransition
        {
            duration = .5f,
            direction = false,
            inverse = false
        };
        
        protected override UiTransition OutTransition { get; set; } = new HSlideTransition
        {
            duration = 0,
            direction = true,
            inverse = false
        };

        //HSlideLeftInverse
        protected virtual UiTransition InTransitionInverse { get; set; } =  new HSlideTransition
        {
            duration = .5f,
            direction = true,
            inverse = true
        };
        
        //HSlideRightInverseInstant
        protected virtual UiTransition OutTransitionInverse { get; set; } =  new HSlideTransition
        {
            duration = 0,
            direction = false,
            inverse = true
        };

        [SerializeField] private List<UiConstants.Page> pages;

        [SerializeField] private int startingIndex;

        private int _pageDiff = 0;
        
        private int _index = 0;

        private void Start()
        {
            pages.ForEach(page =>
            {
                page.toggle.onValueChanged.AddListener(on =>
                {
                    if (on)
                    {
                        //if active (isOn) not to load page while already loaded
                        page.toggle.interactable = false;
                        
                        Load(page.pageAddress.AssetGUID);
                    }

                    else page.toggle.interactable = true;

                    _pageDiff = pages.IndexOf(page) - _index;

                    _index = pages.IndexOf(page);
                });
            });

            pages[startingIndex].toggle.isOn = true;
        }

        protected override Tween TransitionIn()
        {
            Tween inTween;

            if (_pageDiff >= 0)
            {
                InTransition.Transition(this, out inTween);
            }

            else
            {
                InTransitionInverse.Transition(this, out inTween);
            }

            return inTween;
        }

        protected override Tween TransitionOut()
        {
            Tween outTween;

            if (_pageDiff > 0)
            {
                OutTransition.Transition(this, out outTween);
            }

            else
            {
                OutTransitionInverse.Transition(this, out outTween);
            }

            return outTween;
        }
    }
}
