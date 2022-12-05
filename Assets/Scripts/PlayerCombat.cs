using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public Transform attackPoint2;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public int attackDamage2 = 100;
    public float attackRange2 = 2f;

    public float attackRate = 2f;
    public float attackRate2 = 2f;
    float nextAttackTime = 0f;

    private ShakeCam shake;

    void Start(){
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeCam>();
    }
    
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            attackDamage=100;
            Attack();
            nextAttackTime = Time.time +1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1)) 
            {
            attackDamage = 100;
            Attack2();
            nextAttackTime = Time.time +1f / attackRate2;
            }
        }

    }
    void Attack()
    {
        // ataca
        animator.SetTrigger("Attack");

        //Audio
        FindObjectOfType<AudioManager>().Play("PlayerHit");


        //detectar inimigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange , enemyLayers);

        // inflingir dano
        foreach(Collider2D enemy in hitEnemies){

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
        void Attack2()
    {
        // ataca
        animator.SetTrigger("Attack2");

        //Audio
        FindObjectOfType<AudioManager>().Play("PlayerHeavy");

        shake.camShake();

        //detectar inimigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2 , enemyLayers);

        // inflingir dano
        foreach(Collider2D enemy in hitEnemies){
            
            enemy.GetComponent<Enemy>().TakeDamage(100);
        }
    }

    void OnDrawGizmosSeleted(){

        if(attackPoint==null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
    }
}
