using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static int totalMonedas;
    public static int totalObjetos;
    private int precioObjeto;
    [SerializeField] private TextMeshProUGUI txtMonedas;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;
    [SerializeField] private GameObject panelEquipo;
    [SerializeField] private Sprite corazonActivado;

    public static GameObject equipo;

    private void Start()
    {
        Moneda.sumaMoneda += SumarMonedas;
        totalMonedas = ControladorPuntos.totalMonedas;
        txtMonedas.text = ControladorPuntos.totalMonedas.ToString();
        equipo = ControladorPuntos.equipo;
        totalObjetos = ControladorPuntos.totalObjetos;
        ActualizarCorazones(ControladorPuntos.vidaPersonaje);
    }

    //se le asigna el valor de la moneda al total de monedas
    //y se muestra en el texto
    private void SumarMonedas(int moneda)
    {
        totalMonedas = ControladorPuntos.totalMonedas;
        txtMonedas.text = ControladorPuntos.totalMonedas.ToString();

    }
    //creamos una imagen que almacene la imagen del corazon en cuestion
    //y se le asigna la imagen del corazon desactivado
    public void RestaCorazon(int vida)
    {
        vida = ControladorPuntos.vidaPersonaje - 1;
        Image imagenCorazon = listaCorazones[vida].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }
    public void ActualizarCorazones(int vida)
    {
        for (int i = 0; i < listaCorazones.Count; i++)
        {
            if (i < vida)
            {
                listaCorazones[i].SetActive(true); // Activar corazón si está dentro de la vida del personaje
            }
            else
            {
                Image imagenCorazon = listaCorazones[i].GetComponent<Image>();
                imagenCorazon.sprite = corazonDesactivado; // Desactivar corazón si está fuera de la vida del personaje
            }
        }
    }

    public void SumarCorazon(int vida)
    {
        vida = ControladorPuntos.vidaPersonaje;
        Image imagenCorazon = listaCorazones[vida - 1].GetComponent<Image>();
        imagenCorazon.sprite = corazonActivado;
    }
    public void SumarCorazon2(int vida)
    {
        Debug.Log("Vida: " + vida);
        if (vida == 3)
        {
            vida = ControladorPuntos.vidaPersonaje;
            Image imagenCorazon2 = listaCorazones[vida - 2].GetComponent<Image>();
            imagenCorazon2.sprite = corazonActivado;
            Image imagenCorazon = listaCorazones[vida - 1].GetComponent<Image>();
            imagenCorazon.sprite = corazonActivado;
        }
        else
        {
            vida = ControladorPuntos.vidaPersonaje;
            Image imagenCorazon = listaCorazones[vida - 1].GetComponent<Image>();
            imagenCorazon.sprite = corazonActivado;
        }
    }

    #region TIENDA  
    public void PrecioObjeto(string objeto)
    {
        switch (objeto)
        {
            case "PocionCuracionPeq":
                precioObjeto = 5;
                break;
            case "PocionCuracionGrand":
                precioObjeto = 10;
                break;
            case "PocionVelocidad":
                precioObjeto = 20;
                break;
        }
        

    }
    public void AdquirirObjeto(string objeto)
    {
        PrecioObjeto(objeto);
        if (precioObjeto <= totalMonedas && totalObjetos < 3)
        {
            totalObjetos++;
            ControladorPuntos.instance.RestaMonedas(precioObjeto);
            totalMonedas -= precioObjeto;
            txtMonedas.text = totalMonedas.ToString();

            equipo = (GameObject)Resources.Load(objeto);
            ControladorPuntos.equipo = (GameObject)Resources.Load(objeto);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform);

        }
    }
    #endregion
}
