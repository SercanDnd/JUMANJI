using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSpell : MonoBehaviour
{
    PlayerController playerController;
    public int numberOfSpell;
    public bool usable, isPlay;
    public float normalSpeed;
    public float normalRotationSpeed;
    public TextMeshProUGUI spellCountText;
    public float spellTime;
    public Button spellButton;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        normalRotationSpeed = playerController._rotateSpeed;
        normalSpeed = playerController._moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        spellCountText.text = numberOfSpell.ToString();
        
        CheckUsable();
    }

    public void SetSpeed()
    {
        playerController._moveSpeed = normalSpeed + (normalSpeed / 100) * 75;
        playerController._rotateSpeed = normalRotationSpeed + (normalRotationSpeed / 100) * 75;
        Invoke("SetNormalSpeed", spellTime);
        isPlay = true;
        numberOfSpell -= 1;
    }

    public void SetNormalSpeed()
    {
        playerController._moveSpeed = normalSpeed;
        playerController._rotateSpeed = normalRotationSpeed;
        isPlay = false;
    }

    public void CheckUsable()
    {
        isCanUseSpell();
    }

   




    public void isCanUseSpell()
    {
        if (numberOfSpell > 0)
        {
            usable= true;
            spellButton.interactable = true;
        }
        else
        {
            usable=false;
            spellButton.interactable = false;
        }
    }

}
