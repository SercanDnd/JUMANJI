using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeMacig : MonoBehaviour
{
    public int numberOfMacig;
    public bool usable, isPlay;
    public Button button;

    public float normalSpeed;
    public float slowedSpeed;

    public List<GameObject> enemies;
    public TextMeshProUGUI spellCountText;
    public float macigTime;
    void Start()
    {
        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (!enemies.Contains(_enemies[i]))
            {
                enemies.Add(_enemies[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        spellCountText.text = numberOfMacig.ToString();
        CheckUsable();
        SetButtonIn();
    }

    public void SetSpeed()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().Speed = slowedSpeed;

            enemy.GetComponent<Animator>().SetFloat("AnimSpeed", 0.2f);
        }
        isPlay = true;
        Invoke("SetSpeedNormal",macigTime); numberOfMacig -= 1;
    }

    public void SetSpeedNormal()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().Speed = normalSpeed;
            enemy.GetComponent<Animator>().SetFloat("AnimSpeed", 1);
        }
        isPlay = false;
    }

    public void SetButtonIn()
    {
        if (usable == true)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;

        }
    }
    public void CheckUsable()
    {
        if (isCanUseMacig())
        {
            usable = true;
        }
        else
        {
            usable = false;
        }
    }
    public bool isCanUseMacig()
    {
        if (numberOfMacig > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
