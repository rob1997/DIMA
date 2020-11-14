using System;
using System.Collections.Generic;
using Transition;
using Transition.BiDirectional;
using UnityEngine;
using Util;

namespace Hierarchy.Region
{
    public class TabRegion : UiRegion
    {
        //in ScaleOut
        //out ScaleInInstant
        protected override UiTransition InTransition { get; set; } = new ScaleTransition{duration = .5f, direction = true};
        protected override UiTransition OutTransition { get; set; } = new ScaleTransition{duration = 0, direction = false};
        
        [SerializeField] private List<UiConstants.Page> tabs;

        [SerializeField] private int startingIndex;
        
        private void Start()
        {
            tabs.ForEach(tab => 
            {
                tab.toggle.onValueChanged.AddListener( on => 
                {
                    if (on)
                    {
                        //if active (isOn) not to load page while already loaded
                        tab.toggle.interactable = false;
                        
                        Load(tab.pageAddress.AssetGUID);
                    }

                    else tab.toggle.interactable = true;
                });
            });

            tabs[startingIndex].toggle.isOn = true;
        }
    }
}
