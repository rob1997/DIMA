using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    [RequireComponent(typeof(Graphic))]
    public class Colorize : MonoBehaviour
    {
        public enum Order
        {
            Backdrop,
            Primary,
            Secondary,
            Tertiary,
            AlertSuccess,
            AlertError
        }

        public Order order = Order.Primary;

        private Graphic _graphic;
        
        private void Awake()
        {
            _graphic = GetComponent<Graphic>();
            _graphic.color = Solve();
        }

        Color Solve()
        {
            switch (order)
            {
                case Order.Backdrop:

                    return UiManager.Instance.uiRoot.profile.backdropColor;
                
                case Order.Primary:

                    return UiManager.Instance.uiRoot.profile.primaryColor;

                case Order.Secondary:

                    return UiManager.Instance.uiRoot.profile.secondaryColor;

                case Order.Tertiary:

                    return UiManager.Instance.uiRoot.profile.tertiaryColor;
                
                case Order.AlertSuccess:

                    return UiManager.Instance.uiRoot.profile.successAlertColor;
                
                case Order.AlertError:

                    return UiManager.Instance.uiRoot.profile.errorAlertColor;

                default:

                    return Color.white;
            }
        }

#if UNITY_EDITOR

        private void Update()
        {
            _graphic.color = Solve();
        }

#endif
    }
}
