using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WE.UI;

namespace WE.Manager
{
    public class UIGameManager : MonoBehaviour
    {
        public static UIGameManager Instance;

        public UIBase currentGameUI;
        UIBase pendingUI;

        private void Awake()
        {
            Instance = this;
        }

        public void PendingUI(UIBase ui)
        {
            pendingUI = ui;
        }
    }
}

