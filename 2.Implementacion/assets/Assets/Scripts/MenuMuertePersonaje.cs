using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class MenuMuertePersonaje : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private MovimientoPersonaje movimientoPersonaje;
    
    public void Start()
    {
        movimientoPersonaje=GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoPersonaje>();
        movimientoPersonaje.MuerteJugador += ACtivarMenu;
    }
    public void ACtivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }
   public void ReiniciarNivel()
    {
        MovimientoPersonaje.velocidad=3f;
        ItemFinal.contadorGemasRecogidas=0;
        ControladorPuntos.vidaPersonaje=3;
        ControladorPuntos.totalMonedas=0;
        ControladorPuntos.velocidad=3;
        //cargar la escena con index 1
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void MenuPrincipal(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
