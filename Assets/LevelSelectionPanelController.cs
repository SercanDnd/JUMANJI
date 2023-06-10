using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPanelController : MonoBehaviour
{
    public int currentLevel;
    public List<Button> buttons = new List<Button>();
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("level");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var button in buttons)
        {
            if (button.gameObject.GetComponent<LevelSlotController>().level > currentLevel)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
