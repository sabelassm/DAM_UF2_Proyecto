using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFinal : MonoBehaviour
{
    public static int contadorGemasRecogidas = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            contadorGemasRecogidas++;
            Debug.Log("Gemas recogidas: " + GetContadorGemasRecogidas());
        }
    }
    public static int GetContadorGemasRecogidas()
    {
        return contadorGemasRecogidas;
    }
}
