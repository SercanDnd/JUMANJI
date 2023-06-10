using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public static PlayerAttackController instance;
    public GameObject target;
    public GameObject playerObject;
    public LayerMask enemyLayer;
    Collider[] enemies;
    public float targetRadius;
    public GameObject fireBallPrefab;
    public Transform fireballPosition;
    public Vector3 fireballSize;
    public float attackRadius;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemies(playerObject.transform.position, targetRadius,enemyLayer);
        if (GetClosestEnemy(enemies) != null)
        {
            if (target == null)
            {
                target = GetClosestEnemy(enemies).transform.gameObject; 
            }
          
        }
        else
        {
            target = null;
        }
        

        if(target != null)
        {
            if ((target.transform.position-transform.position).magnitude<=attackRadius)
            {
                if (PlayerController.instance.animator.GetBool("CanRun") == false)
                {
                    if (PlayerController.instance.animator.GetBool("FireMacig") == false)
                    {

                        PlayerController.instance.animator.SetBool("CanAttack", true);
                    }
                    else
                    {
                        PlayerController.instance.animator.SetBool("CanAttack", false);
                    }
                }
            }
           
           
        }
    }

    public void GetEnemies(Vector3 center, float radius,LayerMask layerMask)
    {
        
            Collider[] hitColliders = Physics.OverlapSphere(center, radius,layerMask);
            enemies = hitColliders;
        

    }

    Collider GetClosestEnemy(Collider[] enemies)
    {
        Collider tMin = null;
        
            if (enemies.Length != 0)
            {

                float minDist = Mathf.Infinity;
                Vector3 currentPos = transform.position;
                foreach (Collider t in enemies)
                {
                    float dist = Vector3.Distance(t.transform.position, currentPos);
                    if (dist < minDist)
                    {
                        tMin = t;
                        minDist = dist;
                    }
                }

                return tMin;
            }
            else
            {
                return null;
            }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerObject.transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerObject.transform.position, targetRadius);
    }


    public void Attack()
    {

        GameObject fireBall = Instantiate(fireBallPrefab, transform.position, Quaternion.identity);
        fireBall.transform.position = fireballPosition.position;
        
        fireBall.transform.localScale = fireballSize;
       fireBall.GetComponent<ProjectileMoveScript>().target=target.transform;
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), fireBall.GetComponent<BoxCollider>());

    }
  
}
