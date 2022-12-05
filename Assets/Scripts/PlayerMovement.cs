using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 40f;
    public ParticleSystem dust;

    float horizontalMove = 0f;

    bool jump = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            dust.Play();
            jump = true;
            animator.SetBool("isJumping",true);
        }
    }

    public void OnLanding(){      
        animator.SetBool("isJumping",false);
    }

    void FixedUpdate () {
        // Mover o Personagem
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
        if(rb.position.y < -3){
            Debug.Log("Player dies");

                 
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerCombat>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    void CreateDust(){
        dust.Play();
    }
}
