using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    GameManager gameManager;

    public Animator anim;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //anim = GetComponentInParent<Mario>();
        //anim = GetComponentInParent<PlayerController>();
        anim.GetComponent<Animator>();
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            anim.SetBool("IsJumping", true);
        }  
    }*/

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            anim.SetBool("IsJumping", true);
        }

        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
            //anim.SetBool("IsJumping", false);
        }
        else if(collider.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");
            
            Enemy goomba = collider.gameObject.GetComponent<Enemy>();
            goomba.Die();
        }

        if(collider.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estoy muerto");

            gameManager.GameOver();
        }  
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
