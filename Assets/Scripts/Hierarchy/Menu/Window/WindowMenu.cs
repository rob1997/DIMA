using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Hierarchy.Menu.Window
{
    public class WindowMenu : UiMenu
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private Graphic messageGraphic;
        
        [SerializeField] private Button closeButton;
        [SerializeField] private AssetReference windowButtonAddress;
        
        [SerializeField] private Transform buttonGrid;

        private void Start()
        {
            closeButton.onClick.AddListener(delegate { region.Unload(); });
        }

        public void Attach(Hierarchy.Window.Window window)
        {
            messageText.text = window.Message;
            messageGraphic.color = window.DisplayColor;

            window.WindowActions?.ForEach(action =>
            {
                Addressables.LoadAssetAsync<GameObject>(windowButtonAddress)
                    .Completed += response =>
                {
                    if (!response.IsValid() || response.Status != AsyncOperationStatus.Succeeded)
                    {
                        Debug.LogError($"can't find prefab {windowButtonAddress.AssetGUID}");
                        
                        return;
                    }

                    GameObject obj = Instantiate(response.Result, buttonGrid);

                    obj.GetComponentInChildren<TextMeshProUGUI>().text = action.Message;
                    obj.GetComponent<Graphic>().color = action.DisplayColor;

                    Button windowButton = obj.GetComponent<Button>();
                    
                    action.OnClick.ForEach(listener =>
                    {
                        windowButton.onClick.AddListener(delegate { listener(); });
                    });
                };
            });
        }
    }
}
