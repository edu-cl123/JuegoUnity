using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque1 : MonoBehaviour
{
    private Animator anim;
    public Transform attackPoint;
    public Transform attackPoint3;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 10;
    public int sp_attackDamage = 30;
    public int attackDamage_3 = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.J))
            {
                if (PlayerPrefs.GetInt("Personaje") == 1)
                
                {   if(PlayerPrefs.GetInt("IA")==1){
                    Debug.Log("Me bugeado");

                }
                    F_Attack();
                }
                else if (PlayerPrefs.GetInt("Personaje") == 2)
                {
                    W_Attack();
                }
                else
                {
                    Attack();
                }


                nextAttackTime = Time.time + 0.4f / attackRange;
            }
        }
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.L))
            {
                if (PlayerPrefs.GetInt("Personaje") == 1)
                {
                    F_sp_Attack();
                }
                else if (PlayerPrefs.GetInt("Personaje") == 2)
                {
                    W_sp_Attack();
                }
                else
                {
                    sp_Attack();
                }


                nextAttackTime = Time.time + 0.5f / attackRange;
            }
        }
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.K))
            {
                if (PlayerPrefs.GetInt("Personaje") == 1)
                {
                    F_Attack_3();
                }
                else if (PlayerPrefs.GetInt("Personaje") == 2)
                {
                    W_Attack_3();
                }
                else
                {
                    Attack_3();
                }


                nextAttackTime = Time.time + 1f / attackRange;
            }
        }

    }


    void Attack()
    {
        //Animación de atacar
        anim.SetTrigger("Attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {

                if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage);
            }
            else if(PlayerPrefs.GetInt("IA") == 2){ enemy.GetComponent<Enemy>().TakeDamage(attackDamage); }

        }
    }

    void Attack_1()
    {
        //Animación de atacar
        anim.SetTrigger("Attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
                if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage); }
        }
    }

    void F_Attack()
    {
        //Animación de atacar
        anim.SetTrigger("F_attack");

        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {

            if (PlayerPrefs.GetInt("IA") == 1)
            {
                Debug.Log("DEntro de aqui");
                //enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage); }
        }
    }

    

    void W_Attack()
    {
        //Animación de atacar
        anim.SetTrigger("W_attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {

            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage); }

        }
    }

   
    void sp_Attack()
    {
        //Animación de atacar
        anim.SetTrigger("sp_attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(sp_attackDamage); }


        }
    }

    void F_sp_Attack()
    {
        //Animación de atacar
        anim.SetTrigger("F_attack_sp");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {


            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(sp_attackDamage); }
        }
    }

    void W_sp_Attack()
    {
        //Animación de atacar
        anim.SetTrigger("W_attack_sp");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(sp_attackDamage); }


        }
    }


    void Attack_3()
    {
        //Animación de atacar
        anim.SetTrigger("3_attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage_3); }


        }
    }

    void F_Attack_3()
    {
        //Animación de atacar
        anim.SetTrigger("F_attack_3");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage_3); }


        }
    }

    void W_Attack_3()
    {
        //Animación de atacar
        anim.SetTrigger("W_attack_3");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerPrefs.GetInt("IA") == 1)
            {
                enemy.GetComponent<EnemigoIA>().TakeDamage(attackDamage_3);
            }
            else { enemy.GetComponent<Enemy>().TakeDamage(attackDamage_3); }


        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
