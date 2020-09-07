using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgGround : MonoBehaviour
{
    private bool isGrounded = false;
    
    void Update(){
        
        Debug.Log("接地判定" + isGrounded);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag != "CantJump")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
            isGrounded = false;
    }

    public bool playerOnGround
    {
        get { return this.isGrounded; }
        set { this.isGrounded = value;}
    }
}
