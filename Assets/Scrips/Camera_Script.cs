using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject John;
       
    void Update()
    {
        if (John != null)
        {
            //Posición actual de la cámara
            Vector3 posicion = transform.position;
            
            //Posición de John
            posicion.x = John.transform.position.x;
            posicion.y = John.transform.position.y;

            //La posición actual toma la posición de John
            transform.position = posicion;
        }
       
    }
}
