using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene0PanelScript : MonoBehaviour
{
    public GameObject buy5plus, buyRevive, buy2x, buyed5plus, buyedRevive, buyed2x, panel;
    bool panelActive;
    public static bool reviveGoted, revivecanBuyed, canUse2x, canUse5;
    public Text coinText;
    void Start()
    {

        panelActive = false;
        panel.SetActive(false);
    }


    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        if (PlayerPrefs.GetInt("5+Goted") == 0)
        {
            buy5plus.SetActive(true);
            buyed5plus.SetActive(false);
            canUse5 = false;

        }
        if (PlayerPrefs.GetInt("5+Goted") == 1)
        {
            canUse5 = true;
            buy5plus.SetActive(false);
            buyed5plus.SetActive(true);

            ShieldScript.waitSeconds = ShieldScript.waitSeconds + 5;
        }
        if (PlayerPrefs.GetInt("ReviveGoted") == 0)
        {

            buyRevive.SetActive(true);
            buyedRevive.SetActive(false);


        }
        if (PlayerPrefs.GetInt("ReviveGoted") == 1)
        {
            buyRevive.SetActive(false);
            buyedRevive.SetActive(true);
            reviveGoted = true;
        }
        if (PlayerPrefs.GetInt("2xGoted") == 0)
        {
            buy2x.SetActive(true);
            canUse2x = false;
            buyed2x.SetActive(false);
        }
        if (PlayerPrefs.GetInt("2xGoted") == 1)
        {
            buy2x.SetActive(false);
            canUse2x = true;
            buyed2x.SetActive(true);
        }
        if (ButtonScripts.closeButtonPressed && panelActive)
        {
            panel.SetActive(false);
            panelActive = false;
            ButtonScripts.closeButtonPressed = false;
        }
        if (ButtonScripts.shopButtonPressed && !panelActive)
        {
            panelActive = true;
            panel.SetActive(true);
            ButtonScripts.shopButtonPressed = false;

        }




    }
}
