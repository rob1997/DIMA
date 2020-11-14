using Transition;
using Transition.BiDirectional;

namespace Hierarchy.Region.Bar
{
    public class BottomBarRegion : BarRegion
    {
        //in vSlideUpInverse
        //out vSlideDownInverse
        protected override UiTransition InTransition { get; set; } = new VSlideTransition
        {
            duration = .5f,
            direction = true,
            inverse = true
        };
        
        protected override UiTransition OutTransition { get; set; } = new VSlideTransition
        {
            duration = .5f,
            direction = false,
            inverse = true
        };
    }
}
