using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
   public enum ObjetosEquipo{
        PocionCuracionPeq,
        PocionCuracionGrand,
        PocionVelocidad
   };
   [SerializeField] private ObjetosEquipo tipoObjeto;
   
    
   public void UsarObjeto()
   {
    MovimientoPersonaje personaje=GameObject.FindObjectOfType<MovimientoPersonaje>();
       switch (tipoObjeto)
       {
           case ObjetosEquipo.PocionCuracionPeq:
                if(ControladorPuntos.vidaPersonaje<3){
                    personaje.SumarVida();
                    Destroy(this.gameObject);
                }else if(ControladorPuntos.vidaPersonaje==3){
                    
                }
               break;
           case ObjetosEquipo.PocionCuracionGrand:
                if(ControladorPuntos.vidaPersonaje<2){
                    personaje.SumarVida2();
                    Destroy(this.gameObject);
                }else if(ControladorPuntos.vidaPersonaje==3){
                    
                }
               break;
           case ObjetosEquipo.PocionVelocidad:
                personaje.VelocidadPersonaje();
                ControladorPuntos.instance.VelocidadPersonaje();
                Debug.Log("Velocidad");
                Destroy(this.gameObject);
               break;
       }
       UIManager.totalObjetos--;
       
   }

}
