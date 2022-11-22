using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WE.UI
{
    public class ScenceLoading : MonoBehaviour
    {
        [SerializeField]
        private Text textLoading;
        [SerializeField]
        private RectTransform panelLoading;
        float maxWidth = 0;

        private void Awake()
        {
            maxWidth = panelLoading.sizeDelta.x;
            panelLoading.sizeDelta = new Vector2(0, panelLoading.sizeDelta.y);
        }
    }

}
