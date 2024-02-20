using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce; 
    public GameObject BulletPrefab;
    public HUD hud;

    private float Horizontal;    
    private Rigidbody2D rb;
    private Animator Animator;
    private bool Grounded; 
    private float LastShoot;
    private int Health = 3; 

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //en el arranque del juego, todos los parámetros rigidbody de john
        Animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        //Si se pulsa la tecla w y está en el suelo, John salta
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            Jump(); //Método que realizará el salto
        }

        //Si se pulsa la tecla espacio y ha pasdo un pequeño tiempo desde que John disparó, el personaje lanza una bala
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //Entre -1 y 1

        Animator.SetBool("running", Horizontal != 0.0f);

        if(Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }else if(Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else { 
            Grounded = false;
        }

        rb.velocity = new Vector2(  //Nuevo vector 2D
            Horizontal * Speed,     //velocidad en eje x
            rb.velocity.y           //velocidad en eje y
            );

    }

    /// <summary>
    /// Método que hace que el personaje salte
    /// </summary>
    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }

    /// <summary>
    /// Método que hace que el personaje dispare
    /// </summary>
    private void Shoot()
    {
        Vector3 direction;

        if(transform.localScale.x == 1.0f) 
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;            
    }

    public void Heal()
    {
        Health = Health + 1;
    }
}
