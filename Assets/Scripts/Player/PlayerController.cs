using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
     public FloatingJoystick joystick;
    public GameObject _playerModel;
    public float _moveSpeed;
    public float _rotateSpeed;
    private Vector3 _moveVector;
    private Rigidbody _rigidbody;
    public Animator animator;
    public bool canMove;
    public float health;
    public bool isDie;
    public bool targetable=true;
    public GameObject hitEffect;
    public float MoveVectorDir;
    public Slider healtBar;
    public bool a;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _rigidbody = GetComponent<Rigidbody>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            Move();
        }
        CheckHealth();
        SetHealthBar();
    }


    public void Move()
    {
        _moveVector = Vector3.zero;
        if (a == false)
        {
            _moveVector.x = +joystick.Horizontal * _moveSpeed * Time.deltaTime;
            _moveVector.z = +joystick.Vertical * _moveSpeed * Time.deltaTime;
        }
        else
        {
            _moveVector.x = -joystick.Horizontal * _moveSpeed * Time.deltaTime;
            _moveVector.z = -joystick.Vertical * _moveSpeed * Time.deltaTime;
        }
     

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {

            Vector3 direction = Vector3.RotateTowards(_playerModel.transform.forward, -_moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
           _playerModel.transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("CanRun",true);
            animator.SetBool("CanAttack", false);
        }
        else
        {
            animator.SetBool("CanRun", false);
        }

        _rigidbody.MovePosition(_rigidbody.position - _moveVector);
    }

    public void SetHealthBar()
    {
        healtBar.value = health;
    }

    public void SetBoolOf()
    {
        canMove = true;
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            isDie = true;
        }else if (health > 0)
        {
            isDie = false;
        }
    }

    public void DeathController()
    {
        bool dieAnim=new bool();
        if (isDie == true)
        {
            if (dieAnim == false)
            {
                //die animation Play
                dieAnim = true;
            }
            targetable = false;

        }
    }

    public void GetDamage(float damage)
    {
        hitEffect.GetComponent<ParticleSystem>().Play();
        health-= damage;
    }
}
