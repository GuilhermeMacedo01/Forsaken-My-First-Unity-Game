using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;
    
    public Healthbar healthBar;
    
    private ShakeCam shake;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeCam>();
    }

    public void  TakeDamage(int damage){

        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        shake.camShake();
        //Plat Hurt Animation

        if(currentHealth<=0){
            Die();
        }

    }

    void Die(){

        FindObjectOfType<GameManager>().GameOver();
        Debug.Log("Player dies");

        animator.SetBool("IsDead",true);        
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        this.enabled = false;

       
    }
}
