using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;

    public GameObject panel;

    public List<GameObject> panels;
    private Vector3 _panelSize;
    [SerializeField] List<GameObject> _openedPanels; 
    private void Awake()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Panel");
        for (int i = 0; i < p.Length; i++)
        {
            if (!panels.Contains(p[i]) && p[i] != panel.gameObject)
            {

                panels.Add(p[i]);
            }
        }
        _panelSize = panel.transform.localScale;
      

        
    }
    void Start()
    {

        SetBool();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in panels)
        {
            if (item.GetComponentInParent<PanelController>().isOpen == true)
            {
                if(!_openedPanels.Contains(item))
                _openedPanels.Add(item);
                
            }
            else
            {
                _openedPanels.Remove(item);
            }
        }
    }
   
    public void SpellPanelCheck()
    {
       
        if (isOpen == true)
        {
            CloseAnimation();
        }
        else
        {

            OpenAnimation();
        }
    }

    public void SetBool()
    {
        if (isOpen == true)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }

        SpellPanelCheck();
    }

    public void CloseAnimation()
    {
       
       
        panel.transform.DOScale(Vector3.zero, 1f);
        panel.SetActive(false);

    }

    public void OpenAnimation()
    {
        foreach (var item in panels)
        {
            if (item.GetComponentInParent<PanelController>().panel.gameObject.activeInHierarchy)
            {
                item.GetComponentInParent<PanelController>().SetBool();
               
            }
            
        }
        panel.SetActive(true);
        panel.transform.DOScale(_panelSize, 1f);
    }
}
