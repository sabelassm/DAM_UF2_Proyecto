using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueOrco : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            MovimientoPersonaje mp = other.GetComponent<MovimientoPersonaje>();
            mp.CausarHerida();
        }
    }
}
