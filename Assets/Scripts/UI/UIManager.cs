using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UI Manager is Null!");
            }
            return instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;
    public Text gemsHUD;
    public Image[] healthBars;
    private void Awake()
    {
        instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = ""+gemCount +"G";
    }

    public void UpdateShopSelection(float yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    
    public void UpdateGemCount(int count)
    {
        gemsHUD.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
}
