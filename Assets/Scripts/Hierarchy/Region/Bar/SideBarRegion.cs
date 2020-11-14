using DG.Tweening;
using Transition;
using Transition.BiDirectional;

namespace Hierarchy.Region.Bar
{
    public class SideBarRegion : BarRegion
    {
        //in 
        //out 
        protected override UiTransition InTransition { get; set; } = new HSlideTransition
        {
            duration = .25f,
            direction = true,
            inverse = true
        };
        
        protected override UiTransition OutTransition { get; set; } = new HSlideTransition
        {
            duration = .25f,
            direction = false,
            inverse = true
        };

        protected override void Awake()
        {
            base.Awake();
            
            //Transition region instantly to the left on initialize
            new HSlideTransition
            {
                duration = 0,
                direction = false,
                inverse = true
            }.Transition(this, out Tween initialTween);
        }
    }
}
