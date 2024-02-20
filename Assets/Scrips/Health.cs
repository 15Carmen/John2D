using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Movement john = other.GetComponent<Movement>();

        if (other.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = GameManager.Instance.RecuperarVida();
            john.Heal();

            if (vidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
