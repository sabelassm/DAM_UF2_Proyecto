using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCambioEscena : MonoBehaviour
{
    private BoxCollider2D bc;
    ItemFinal itemFinal;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();

        if (bc.gameObject.CompareTag("BordeIzquierda"))
        {

            if(ItemFinal.GetContadorGemasRecogidas() == 0)
            {
                
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }

        if (bc.gameObject.CompareTag("SuperiorIzq"))
        {
           
            if(ItemFinal.GetContadorGemasRecogidas() == 1)
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }

        if (bc.gameObject.CompareTag("BordeSuperior"))
        {
            if(ItemFinal.GetContadorGemasRecogidas() == 2)
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }
        
        
    }
}


