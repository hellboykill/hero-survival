using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WE.Manager;

namespace WE.UI
{
    public abstract  class UIBase : MonoBehaviour
    {
        public Button CloseButton;
        public GameObject blockPanel;
        public Animator UiAnim;

        public static string openAnim = "Open";
        public static string normalAnim = "Normal";
        public static string closeAnim = "Close";

        protected bool IsInited = false;
        public bool IsControllTimeScale = false;
        public bool IsActiveBackButton = false;
        public bool IsGameplayUI = false;

        protected bool isClosing;

        public virtual bool CanBack
        {
            get => !isClosing;
        }
        public virtual void Show()
        {
            
            gameObject.SetActive(true);
            blockPanel.SetActive(false);
         //   InitUI();
            IsInited = true;
            StartCoroutine(IEShow());

        }

        public virtual void Hide()
        {
            if (!gameObject.activeInHierarchy)
                return;
            if (CloseButton != null)
                CloseButton.onClick.RemoveListener(Hide);
            isClosing = true;
            IsInited = false;
            StartCoroutine(IEHide());
        }
        public virtual IEnumerator IEShow()
        {
            if (UiAnim != null)
            {
                UiAnim.Play(openAnim);
                yield return new WaitForSecondsRealtime(0.2f);
                //UiAnim.Play(normalAnim);
            }
            blockPanel.SetActive(false);
            isClosing = false;
            ActionAfterShow();
        }
        public virtual IEnumerator IEHide()
        {
            blockPanel.SetActive(true);
            if (UiAnim != null)
            {
                UiAnim.Play(closeAnim);
                yield return new WaitForSecondsRealtime(0.25f);
            }
            if (UIGameManager.Instance.currentGameUI != null)
            {
                if (UIGameManager.Instance.currentGameUI == this)
                {
                    UIGameManager.Instance.currentGameUI = null;
                }
            }
            if (IsControllTimeScale)
            {
                TimerSystem.Instance.ReturnTimeScale();
            }
            AfterHideAction();
            gameObject.SetActive(false);
        }
        public virtual void AfterHideAction()
        {

        }
        public virtual void ActionAfterShow()
        {

        }
        public abstract void InitUI();
    }

}
