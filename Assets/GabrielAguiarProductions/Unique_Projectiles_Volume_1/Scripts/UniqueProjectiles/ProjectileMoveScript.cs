//
//
//NOTES:
//
//This script is used for DEMONSTRATION porpuses of the Projectiles. I recommend everyone to create their own code for their own projects.
//THIS IS JUST A BASIC EXAMPLE PUT TOGETHER TO DEMONSTRATE VFX ASSETS.
//
//




#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour {

    public float speed = 10f;
    public float damage = 10f;

    public Transform target;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Hedef yoksa mermiyi yok et
            return;
        }

        // Hedefe doğru yönel
        Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z);
        float distanceThisFrame = speed * Time.deltaTime;

        // Çarpışma kontrolü
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Hedefe doğru ilerle
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void HitTarget()
    {
       

        Destroy(gameObject);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyController>().GetDamage(damage);
        }
    }
}
