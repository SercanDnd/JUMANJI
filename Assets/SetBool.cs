using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBool : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 lookDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanMove()
    {
        PlayerController.instance.animator.SetBool("FireMacig", false);
        PlayerController.instance.canMove = true;
    }

    public void Attack()
    {
        PlayerController.instance._playerModel.transform.LookAt(PlayerAttackController.instance.target.transform.position+lookDistance);
        PlayerAttackController.instance.Attack();
    }
}
