using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void  TakeDamage(int damage){

        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        //Plat Hurt Animation

        if(currentHealth<=0){
            Die();
        }

    }

    void Die(){

        Debug.Log("Enemy dies");

        animator.SetBool("IsDead",true);

        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
