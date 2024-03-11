using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Espada : MonoBehaviour
{
  private BoxCollider2D bc;
  

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

//al entrar en contacto con algun elemento cuya etiqueta sea "Enemigo"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemigo"))
        {
            
            Destroy(other.gameObject);
        }
    }
}
