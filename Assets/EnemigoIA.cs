using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth;
    public GameObject destruir;
    public HealthBar healthBar;
    public int rutina;
    public Rigidbody2D rb;
    public float cronometro;
    public Animator ani;
    public int dirrecion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public Transform attackPoint;
    public Transform attackPoint3;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 10;
    public int sp_attackDamage = 30;
    public int attackDamage_3 = 20;
    public float attackRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        comportamientos();
    }

    public void comportamientos()
    {
        ani.SetBool("run", true);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            rutina = Random.Range(0, 2);
            Attack();
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                ani.SetBool("run", false);
                break;

            case 1:
                dirrecion = Random.Range(0, 2);
                rutina++;
                break;

            case 2:

                switch (dirrecion)
                {
                    case 0:
                        
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);

                        break;
                    case 1:
                        
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        
                        break;
                }

                break;

        }


    }


    void Attack()
    {
        //Animación de atacar
        ani.SetTrigger("Attack");
        //Detectar a los enemigos en el rango
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Aplicar el daño
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

       // ani.SetTrigger("F_hurt");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {

        ani.SetBool("F_died", true);
        this.enabled = false;

    }

    void destruirr()
    {
        Destroy(destruir);
    }
}






