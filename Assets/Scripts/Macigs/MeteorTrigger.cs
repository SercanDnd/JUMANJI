using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetDamage(0.05f);
        }
    }
}
