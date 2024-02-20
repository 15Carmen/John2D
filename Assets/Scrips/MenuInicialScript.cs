using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicialScript : MonoBehaviour
{
   public void JugarNivel1()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Salir_GameOver()
    {
        SceneManager.LoadScene(2);
    }


}
