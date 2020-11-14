using Transition;
using Transition.BiDirectional;

namespace Hierarchy.Region.Bar
{
    public class TopBarRegion : BarRegion
    {
        //in vSlideDown
        //out vSlideUp
        protected override UiTransition InTransition { get; set; } = new VSlideTransition
        {
            duration = .5f,
            direction = false,
            inverse = false
        };
        
        protected override UiTransition OutTransition { get; set; } = new VSlideTransition
        {
            duration = .5f,
            direction = true,
            inverse = false
        };
    }
}
