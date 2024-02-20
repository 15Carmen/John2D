using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int valor = 1;
    public GameManager gameManager;
    public AudioClip Sound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador el que colisiona con la moneda
        if (collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}
