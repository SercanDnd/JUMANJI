using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FallingFireMacig : MonoBehaviour
{
    public int numberOfMacig;
    public bool usable,isPlay;
    public Button button;
    private GameObject _activedFireFalling;
    public GameObject fireParticlePrefab;
    public TextMeshProUGUI spellCountText;
    void Start()
    {
        
    }

   
    void Update()
    {
        CheckUsable();
        SetButtonIn();

        spellCountText.text = numberOfMacig.ToString();
        
        if (_activedFireFalling!=null&&_activedFireFalling.GetComponent<ParticleSystem>().isStopped == true)
        {
            Destroy(_activedFireFalling);
            _activedFireFalling = null;
            isPlay = false;
        }
    }


    public void Fire()
    {
        
            GameObject firePref;
            if (GetComponent<PlayerAttackController>().target != null)
            {
            PlayerController.instance.canMove = false;
            PlayerController.instance.animator.SetBool("FireMacig",true);
            
                firePref = Instantiate(fireParticlePrefab);
                firePref.transform.position = GetComponent<PlayerAttackController>().target.transform.position;
                _activedFireFalling = firePref;
                isPlay = true;
                firePref.GetComponent<ParticleSystem>().Play();
            numberOfMacig -= 1;
            }

        
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
