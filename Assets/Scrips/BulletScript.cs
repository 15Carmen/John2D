using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;             // Factor velocidad de la bala
    public AudioClip Sound;
    
    private Rigidbody2D Rigidbody2D;        // Físicas asociadas a la bala
    private Vector2 Direction;          // Direccion de la bala
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Carga de físicas
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {   // Cálculo de la velocidad de la bala
        Rigidbody2D.velocity = Direction * Speed;
    }


    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement john = collision.GetComponent<Movement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if (john != null)
        {
            john.Hit();
            GameManager.Instance.PerderVida();
        }

        if (grunt != null)
        {
            grunt.HitGrunt();
        }

        DestroyBullet();
    }

}
