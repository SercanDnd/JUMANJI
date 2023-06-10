using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public int gold;
    public TextMeshProUGUI currentGoldText;
    GameObject[] enemiesOnScene;
    public bool gameDone;
    public GameObject portalObject;
    Vector3 portalFirstScale;
    bool levelUp;
    public int level;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        portalFirstScale=portalObject.transform.localScale;
       level= PlayerPrefs.GetInt("level");
        if(level == 0)
        {
            level = 1;
             PlayerPrefs.SetInt("level",1);
        }

      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPortalOn();
        currentGoldText.text = gold.ToString();
        enemiesOnScene = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesOnScene.Length <= 0)
        {
            gameDone = true;
            UpLevel();
        }
        else
        {
            gameDone = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("level", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void SetPortalOn()
    {
        if (gameDone == true)
        {
            //Portal on
            portalObject.transform.DOScale(portalFirstScale, 1f);
        }
        else
        {
            //portal off;
            portalObject.transform.DOScale(Vector3.zero, 0.5f);
        }
    }

    public void UpLevel()
    {
        if (levelUp == false)
        {
            levelUp= true;
            PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level") + 1);
            Debug.Log("LevelUp New Level " + PlayerPrefs.GetInt("level"));
        }
    }
}
