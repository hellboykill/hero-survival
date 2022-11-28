using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Data.User;

public class CurrencyButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textValue;
    private void Start()
    {
        switch(this.name)
        {
            case "Gold":
                textValue.text = PlayerSubData.Instance.Gold.ToString();
                break;
            case "Energy":
                textValue.text = PlayerSubData.Instance.Energy.ToString();
                break;
        }
        
    }

}
