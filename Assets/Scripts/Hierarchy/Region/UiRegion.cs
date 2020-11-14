using DG.Tweening;
using Hierarchy.Layer;
using Hierarchy.Menu;
using Manager;
using Transition;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Util;

namespace Hierarchy.Region
{
    public abstract class UiRegion : MonoBehaviour
    {
        #region Loaded

        public delegate void Loaded(UiElement uiElement);

        /// <summary>
        /// invoked when Ui element prefab is loaded
        /// </summary>
        public event Loaded OnLoaded;

        /// <summary>
        /// invoked when Ui element prefab is loaded
        /// </summary>
        /// <param name="uiElement"><see cref="UiElement"/> of the loaded prefab</param>
        public void InvokeLoaded(UiElement uiElement)
        {
            OnLoaded?.Invoke(uiElement);
        }

        #endregion

        #region LoadComplete

        public delegate void LoadComplete(UiElement uiElement);

        /// <summary>
        /// invoked when the <see cref="UiElement"/> has finished its transition load
        /// </summary>
        public event LoadComplete OnLoadComplete;

        /// <summary>
        /// invoked when the <see cref="UiElement"/> has finished its transition load
        /// </summary>
        /// <param name="uiElement">the loaded menu</param>
        public void InvokeLoadComplete(UiElement uiElement)
        {
            OnLoadComplete?.Invoke(uiElement);
        }

        #endregion
        
        [HideInInspector] public UiElement element;

        protected abstract UiTransition InTransition { get; set; }
        protected abstract UiTransition OutTransition { get; set; }

        [HideInInspector] public Vector3 idleLocalPosition;

        protected virtual void Awake()
        {
            idleLocalPosition = transform.localPosition;
        }
        
        public virtual void Load(string address)
        {
            Addressables.LoadAssetAsync<GameObject>(address)
                .Completed += response =>
            {
                if (!response.IsValid() || response.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"can't load prefab {address}");

                    return;
                }

                Unload().onComplete += delegate
                {
                    element = Instantiate(response.Result, transform).GetComponent<UiElement>();

                    element.region = this;
                    
                    InvokeLoaded(element);

                    Tween inTween = TransitionIn();
                    
                    inTween.onComplete += delegate { InvokeLoadComplete(element); };
                };
            };
        }

        protected virtual Tween TransitionIn()
        {
            transform.DOComplete();
            
            InTransition.Transition(this, out Tween inTween);

            return inTween;
        }

        protected virtual Tween TransitionOut()
        {
            transform.DOComplete();
            
            OutTransition.Transition(this, out Tween outTween);

            return outTween;
        }

        public virtual Tween Unload()
        {
            Tween outTween = TransitionOut();

            outTween.onComplete += delegate 
            {
                if (element != null)
                {
                    Destroy(element.gameObject);
                }
            };

            return outTween;
        }
    }
}
