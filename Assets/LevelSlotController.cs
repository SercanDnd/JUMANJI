using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSlotController : MonoBehaviour
{
    public int levelSceneIndex;
    public int level;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel()
    {
        SceneManager.LoadScene(levelSceneIndex);
    }
}
