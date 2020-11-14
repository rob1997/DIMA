using Transition;
using Transition.BiDirectional;

namespace Hierarchy.Region
{
    public class BaseRegion : MenuRegion
    {
        //in scaleOut
        //out ScaleIn
        protected override UiTransition InTransition { get; set; } = new ScaleTransition{duration = .5f, direction = true};
        protected override UiTransition OutTransition { get; set; } = new ScaleTransition{duration = .5f, direction = false};
    }
}
