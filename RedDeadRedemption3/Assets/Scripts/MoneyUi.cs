using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUi : MonoBehaviour
{

    public PlayerInventory playerInventory;
    public TMP_Text moneyText;
    public TMP_Text keyText;

    void Update()
    {
        if (playerInventory != null && moneyText != null)
        {
            moneyText.text = "Argent : " + playerInventory.argent + "$";
            if (playerInventory.cles > 0)
            {
                keyText.text = "Clé x" + playerInventory.cles;
            }
        }
    }
}
