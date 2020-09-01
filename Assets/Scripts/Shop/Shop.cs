
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public string currentSelecction;
    public int currentItemCost;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            shopPanel.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }

    }

    public void SelectItem(String item)
    {



        switch (item)
        {
            case "flameSword":
                UIManager.Instance.UpdateShopSelection(216.42f);
                currentSelecction = "flameSword";
                currentItemCost = 200;
                
                break;

            case "bootsOfFlight":
                UIManager.Instance.UpdateShopSelection(74.525f);
                currentSelecction = "bootsOfFlight";
                currentItemCost = 400;
                break;

            case "keyCastle":
                UIManager.Instance.UpdateShopSelection(-60.575f);
                currentSelecction = "keyCastle";
                currentItemCost = 100;
                break;
        }
    }


    public void BuyItem()
    {
        if (player.diamonds >= currentItemCost)
        {
            player.diamonds -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
        }
        
    }
}
