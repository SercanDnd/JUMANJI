using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class HealtSpell : MonoBehaviour
{

  


    public int numberOfSpell;
    [SerializeField] bool usable;
    public ParticleSystem healtParticle;
    public Light healtLight;
    public float duration;
    public Button healthButton;
    public TextMeshProUGUI spellCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spellCountText.text = numberOfSpell.ToString();
       
        CheckUsable();
       
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
            healthButton.interactable = true;
        }
        else
        {
            usable=false;
            healthButton.interactable = false;
        }
    }

    public void SetHealth()
    {
        Debug.Log("Set Health");
        healtLight.gameObject.SetActive(true);
        healtParticle.Play();
        healtParticle.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        Invoke("CloseLight",duration);
        PlayerController.instance.health += 50;
        numberOfSpell -= 1;

    }

    public void CloseLight()
    {
        healtLight.gameObject.SetActive(false);
    }
}
