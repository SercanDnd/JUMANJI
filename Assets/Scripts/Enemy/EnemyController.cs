using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float health;
    public float stopDistance;
    GameObject player;
    NavMeshAgent agent;
    public float AttackDistance;
    Animator animator;
   [SerializeField] bool inAttackRange, inCheckRange;
    public LayerMask playerLayer;
    public Slider healtSlider;
    public ParticleSystem attackParticles;


    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public float attackCooldown = 2f;


    private Transform target;
   
    private float attackTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent=GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimer = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        agent.speed = Speed;
        SetHealthSlider();
       // CheckPlayerInAttackRange();
        Death();
        // Destination();
        Deneme();
    }


    public void Deneme()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Oyuncuyu algýla
        if (distanceToTarget <= detectionRadius)
        {
            // Oyuncuya doðru koþ
            if (distanceToTarget > attackRadius)
            {
                animator.SetBool("CanWalk", true);
                animator.SetBool("CanAttack", false);
                agent.SetDestination(target.position);
            }
            // Saldýrý mesafesine geldiðinde dur ve saldýrý yap
            else
            {
                agent.SetDestination(transform.position);
                Attack();
            }
        }
        // Oyuncu uzakta ise bekleyin
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    public void Destination()
    {
        if (AttackDistance >= (player.transform.position - transform.position).magnitude)
        {
            if (player.GetComponent<PlayerController>().targetable == true)
            {
                inCheckRange = true;
                
                agent.SetDestination(player.transform.position);
                
                if (inAttackRange == false)
                  
                animator.SetBool("CanAttack", false);
               
            }
            
        }
        else
        {
            inCheckRange = false;
        }
        
        
      
        
        agent.speed = Speed;
       
    }

    public void Particle()
    {
       // Vector3 attackPoint = target.position; // Saldýrýnýn gerçekleþtiði nokta
       // attackParticles.transform.position = attackPoint;
        attackParticles.Play();
    }

    public void CheckPlayerInAttackRange()
    {
        
        Collider[] col = Physics.OverlapSphere(transform.position, stopDistance, playerLayer);
        foreach (var collider in col)
        {
            
            
            if (collider.transform.GetComponent<PlayerController>().targetable == true)
            {
                inAttackRange = true;
                Attack();
            }
            else
            {
                inAttackRange = false;
               
                animator.SetBool("CanAttack", false);
            }
            
            
        }
        
    }

    public void Attack()
    {
        /*  Vector3 direction = player.transform.position - transform.position;
         // direction.y = 0;
          transform.LookAt(direction);
          agent.Stop();
          animator.SetBool("CanAttack", true);*/

        // Saldýrý zamanlayýcýsýný kontrol et
        if (attackTimer >= attackCooldown)
        {
            animator.SetBool("CanWalk", false);
            animator.SetBool("CanAttack", true);
            Debug.Log("Saldýrý!");
           
            // Saldýrý animasyonunu baþlat veya saldýrý kodunu buraya ekleyin

            attackTimer = 0f;
        }

        attackTimer += Time.deltaTime;
    }



  public void SetAttack()
    {
        PlayerController.instance.GetDamage(10f);
    }

    public void Death()
    {
        if (CheckHealth() == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            for (int i = 0; i < player.GetComponent<TimeMacig>().enemies.Count; i++)
            {
                player.GetComponent<TimeMacig>().enemies.RemoveAt(i);
            }
            GameManager.instance.gold += 5;
            Destroy(this.gameObject);
        }
    }

    public bool CheckHealth()
    {
        if (health > 0)
        {
            return true;
        }
        else if(health<=0)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
    }

    public void SetHealthSlider()
    {
        healtSlider.value = health;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

   

   
}
