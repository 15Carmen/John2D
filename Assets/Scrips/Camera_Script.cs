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
            //Posici�n actual de la c�mara
            Vector3 posicion = transform.position;
            
            //Posici�n de John
            posicion.x = John.transform.position.x;
            posicion.y = John.transform.position.y;

            //La posici�n actual toma la posici�n de John
            transform.position = posicion;
        }
       
    }
}
