using System;
using System.Collections;
using Hierarchy.Region;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Hierarchy.Menu.Alert
{
    using Hierarchy.Alert;
    
    public class AlertMenu : UiMenu
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [FormerlySerializedAs("graphic")] 
        [SerializeField] private Graphic messageGraphic;
        
        [FormerlySerializedAs("alertButton")] 
        [SerializeField] private Button messageButton;
        
        [FormerlySerializedAs("backDrop")] 
        [SerializeField] private Button backDropButton;

        private void Start()
        {
            backDropButton.onClick.AddListener(delegate { region.Unload(); });
        }

        public void Attach(Alert alert)
        {
            if (!alert.Notification) return;
            
            messageText.text = alert.Message;
            messageGraphic.color = alert.DisplayColor;

            if (alert.Lifetime > 0f)
            {
                StartCoroutine(WaitAndUnload(alert.Lifetime));
            }

            alert.OnClick?.ForEach(listener =>
            {
                messageButton.onClick.AddListener(delegate { listener(); });
            });
        }

        IEnumerator WaitAndUnload(float time)
        {
            yield return new WaitForSeconds(time);
            
            region.Unload();
        }
    }
}
