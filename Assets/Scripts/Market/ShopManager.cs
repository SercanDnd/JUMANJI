using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentGold;

    [SerializeField] private TextMeshProUGUI _currentGoldText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCurrentGold();
        SetCurrentGoldText();
    }

    public void SetCurrentGold()
    {
        currentGold = GameManager.instance.gold;
    }

    public void SetCurrentGoldText()
    {
        _currentGoldText.text = currentGold.ToString();
    }

  
}
