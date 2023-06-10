using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    ShopManager shopManager;
    public int cost;
    Button _button;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] RawImage itemCashOutBackground;
    [SerializeField] TextMeshProUGUI itemCashOutNameText;
    [SerializeField] TextMeshProUGUI itemCostText;

    public string itemNameText;
    public Color itemBackgroundColor;
    public string itemCashOutName;
    public ShopType shopType;

    public enum ShopType
    {
        fireMagic,
        timeMagic,
        healthSpell,
        speedSpell
    }

    void Start()
    {
        shopManager = GetComponentInParent<ShopManager>();
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonActive();
        SetItemTexts();
    }


    public void ButtonActive()
    {
        if (SetButtonActivite() == true)
        {
            _button.interactable = true;
            SetTrans(false);
        }
        else
        {
            _button.interactable = false;
            SetTrans(true);
        }
    }

    public bool SetButtonActivite()
    {
       
        if (cost<shopManager.currentGold||cost==shopManager.currentGold)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void SetItemTexts()
    {
        itemCostText.text = cost.ToString();
        itemName.text = itemNameText;
        itemCashOutNameText.text = itemCashOutName;
    }

    public void SetTrans(bool setBool)
    {
        
        if (setBool == false)
        {
            Color c;
            c = itemName.color;
            c.a = 0.35f;
            itemName.color = c;
            Color a;
            a = itemCashOutBackground.color;
            a.a = 0.35f;
            itemCashOutBackground.color = a;
            Color b;
            b = itemCashOutNameText.color;
            b.a = 0.35f;
            itemCashOutNameText.color = b;
            Color d;
            d = itemCostText.color;
            d.a = 0.35f;
            itemCostText.color = d;


        }
        else
        {
            Color c;
            c = itemName.color;
            c.a = 1;
            itemName.color = c;
            Color a;
            a = itemCashOutBackground.color;
            a.a = 1;
            itemCashOutBackground.color = a;
            Color b;
            b = itemCashOutNameText.color;
            b.a = 1;
            itemCashOutNameText.color = b;
            Color d;
            d = itemCostText.color;
            d.a = 1;
            itemCostText.color = d;
        }
    }

    public void ShopIt()
    {
        switch (shopType)
        {
            case ShopType.fireMagic:
            PlayerController.instance.gameObject.GetComponent<FallingFireMacig>().numberOfMacig += 1;
                break;
            case ShopType.timeMagic:
                PlayerController.instance.gameObject.GetComponent<TimeMacig>().numberOfMacig += 1;
                break;
            case ShopType.healthSpell:
                PlayerController.instance.gameObject.GetComponent<HealtSpell>().numberOfSpell += 1;
                break;
            case ShopType.speedSpell:
                PlayerController.instance.gameObject.GetComponent<SpeedSpell>().numberOfSpell += 1;
                break;
            
        }
        GameManager.instance.gold -= cost;
    }
}
