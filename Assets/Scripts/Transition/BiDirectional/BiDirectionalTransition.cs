using UnityEngine.Serialization;

namespace Transition.BiDirectional
{
    [System.Serializable]
    public abstract class BiDirectionalTransition : UiTransition
    {
        public bool direction;
    }
}