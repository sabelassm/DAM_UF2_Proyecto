using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Moneda : MonoBehaviour
{
   public delegate void SumaMoneda(int moneda);
   public static event SumaMoneda sumaMoneda;
   [SerializeField] private int cantidadMoneda;
 
   private void OnTriggerEnter2D(Collider2D other)
   {
    if(sumaMoneda != null)
    {
       if (other.CompareTag("Player"))
      {
         ControladorPuntos.instance.SumarMonedas(cantidadMoneda);
         SumarMoneda();
         Destroy(this.gameObject);  
      }
    }  
   }
   //se llama al evento sumaMoneda y se le asigna el valor de la cantidad de monedas
    public void SumarMoneda()
    {
        sumaMoneda(cantidadMoneda);
    }
}
