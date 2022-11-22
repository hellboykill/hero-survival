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
        Debug.Log(this.name);
        switch(this.name)
        {
            case "Gold":
                  Debug.Log(Player.Instance.Gold);
               // textValue.text = Player.Instance.Gold.ToString();
                break;
            case "Energy":
              //  textValue.text = Data.User.Player.Instance.Energy.ToString();
                break;
        }
        
    }

}
