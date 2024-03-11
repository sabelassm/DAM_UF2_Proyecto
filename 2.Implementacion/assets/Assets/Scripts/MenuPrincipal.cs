using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject opciones;
    public void Jugar()
    {
        ControladorPuntos.vidaPersonaje=3;
        ControladorPuntos.totalMonedas=0;
        ControladorPuntos.velocidad=3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void MenuOpciones(){
        opciones.SetActive(true);
    }
}
