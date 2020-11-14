using UnityEngine;
using UnityEngine.Serialization;

namespace Resource.Script.Profile
{
    [CreateAssetMenu(fileName = nameof(UiProfile), menuName = "Ui/Ui Profile")]
    public class UiProfile : ScriptableObject
    {
        public Color backdropColor;
        
        [FormerlySerializedAs("PrimaryColor")]
        public Color primaryColor;

        [FormerlySerializedAs("SecondaryColor")]
        public Color secondaryColor;

        [FormerlySerializedAs("TertiaryColor")]
        public Color tertiaryColor;

        public Color successAlertColor;
        public Color errorAlertColor;
    }
}
