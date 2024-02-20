using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{

    public HUD hud;
    public static GameManager Instance{ get; private set; }
    public int PuntosTotales{ get; private set; }

    private int Health = 3;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Hay más de un GameManager en escena!");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        Health -= 1;

        if (Health == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(1);
        }

        hud.DesactivarVidaHud(Health);
    }

    public bool RecuperarVida()
    {
        if (Health == 3)
        {
            return false;
        }

        
        hud.ActivarVida(Health);    
        Health += 1;
        return true;
    }

    

        
    }



