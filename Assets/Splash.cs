using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LevelScene", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelScene()
    {
        SceneManager.LoadScene(1);
    }
}
