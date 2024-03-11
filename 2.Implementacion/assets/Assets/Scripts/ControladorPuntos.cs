using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos instance;

    public static int totalMonedas=UIManager.totalMonedas;
    public static int vidaPersonaje=MovimientoPersonaje.vidaPersonaje;

    public  static float velocidad=MovimientoPersonaje.velocidad;

    public static int totalObjetos=UIManager.totalObjetos;

    public static GameObject equipo=UIManager.equipo;
    

    private void Awake()
    {
        if (ControladorPuntos.instance == null)
        {
            ControladorPuntos.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SumarMonedas(int moneda)
    {
        totalMonedas += moneda;
    }
    public void RestaMonedas(int moneda)
    {
        totalMonedas -= moneda;
    }
    public void RestaVida()
    {
        vidaPersonaje--;
    }
    public void SumaVida()
    {
        vidaPersonaje++;
    }
    public void SumaVida2()
    {
        vidaPersonaje+=2;
    }
    public void VelocidadPersonaje()
    {
        velocidad += (velocidad * 0.25f);
    }
   
}
