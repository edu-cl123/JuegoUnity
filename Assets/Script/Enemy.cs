using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;

    public int currentHealth;
    public GameObject destruir;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    private float moveDirecction = 0;
    private float maxSpeed = 6;
    //  private float jumpforce = 30;
    private bool facingRight = false;

    private Animator anim;

    float nextJump = 0f;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("Personaje2") == 1)
        {
            anim.SetBool("Fuego", true);

        }
        if (PlayerPrefs.GetInt("Personaje2") == 2)
        {
            anim.SetBool("Water", true);

        }


    }
    // Update is called once per frame
    void Update()
    {
        //Detectar las pulsaciones del mando
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (Time.time > nextJump)
            {
                rb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                nextJump = Time.time + 4f / 2f;
            }


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirecction = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirecction = -1;
        }
        else
        {
            moveDirecction = 0;
        }

        if (moveDirecction != 0)
        {
            if (moveDirecction > 0 && !facingRight)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingRight = true;
            }
            if (moveDirecction < 0 && facingRight)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingRight = false;
            }
        }
    }

    void FixedUpdate()
    {

        //isgrounded = Physics2D.OverlapCircle(idle.transform.position, 0.2f, layerGround);
        //Aplicar las fuerzas
        Vector2 newSpeed = new Vector2(moveDirecction * maxSpeed, rb.velocity.y);
        rb.velocity = newSpeed;
        if (PlayerPrefs.GetInt("Personaje2") == 1)
        {
            anim.SetFloat("F_speed", Mathf.Abs(rb.velocity.x));
        }
        else if (PlayerPrefs.GetInt("Personaje") == 2)
        {
            anim.SetFloat("W_speed", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

    }




    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        if (PlayerPrefs.GetInt("Personaje2") == 1)
        {
            anim.SetTrigger("F_Hurt");
        }
        else if (PlayerPrefs.GetInt("Personaje2") == 2)
        {
           anim.SetTrigger("W_Hurt");
        }
        else
        {
            anim.SetTrigger("Hurt");
        }
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");
        
        if (PlayerPrefs.GetInt("Personaje2") == 1)
        {
            anim.SetBool("F_died", true);
        }
        else if (PlayerPrefs.GetInt("Personaje2") == 2)
        {
            anim.SetBool("W_died", true);
        }
        else
        {
           anim.SetBool("IsDead", true);
        }

        this.enabled = false;
       

    }

    void destruirr()
    {
        Destroy(destruir);
    }
}
