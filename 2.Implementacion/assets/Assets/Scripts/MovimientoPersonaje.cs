using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;
public class MovimientoPersonaje : MonoBehaviour
{
  public static float velocidad=3f;
  
  //hacemos este parametro serializable y en el editor le asignamos el box collider
  [SerializeField] private BoxCollider2D bc;

  private float posX = 1;
  private float posY = 0;
  private Rigidbody2D rb;
  private Animator anim;
  private SpriteRenderer sr;

  public static int vidaPersonaje = 3;
  [SerializeField] UIManager uiManager;
  [SerializeField] AudioSource audioSourceEspada;
  [SerializeField] AudioSource audioSourceMuerte;
  [SerializeField] AudioSource audioSourcePaso;
  public event EventHandler MuerteJugador;


  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponentInChildren<Animator>();
    sr = GetComponentInChildren<SpriteRenderer>();

  }
  void Start()
    {
      vidaPersonaje=ControladorPuntos.vidaPersonaje;
      if (SceneManager.GetActiveScene().buildIndex == 2  ){
        // Restaurar la posición del jugador al cargar la escena
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX", 0f);
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY", 0f);
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ", 0f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
        }
      }    
    }
    public float getVelocidad()
    {
      return velocidad;
    }
  //mediante el metodo update hacemos que si se pulsa el boton izquierdo del raton
  //se reproduzca la animacion de ataque
  //ya que el parametro ataca del animator se activa
  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      anim.SetTrigger("Ataca");
      audioSourceEspada.Play();
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
      CausarHerida();
    }
  }
  private void FixedUpdate()
  {
    Movimiento();
  }
  public void Movimiento()
  {
    //se obtiene el valor de los ejes horizontal y vertical
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    rb.velocity = new Vector2(horizontal, vertical) * velocidad;

    //se le asigna el valor de la velocidad al parametro Camina del animator
    //para que se reproduzca la animacion de caminar
    anim.SetFloat("Camina", Mathf.Abs(rb.velocity.magnitude));


    //si la posicion horizontal es mayor a 0, el personaje mira a la derecha
    //con la ayuda del metodo offset modificacmos la posicion del box collider
    if (horizontal > 0)
    {
      bc.offset = new Vector2(posX, posY);
      sr.flipX = false;
    }
    else if (horizontal < 0)
    {
      bc.offset = new Vector2(-posX, posY);
      sr.flipX = true;
    }
  }
  //se le resta una vida al personaje
  //llamando al metodo restaCorazon del UIManager
  //por medio de una referencia al mismo
  public void CausarHerida()
  {
    if (vidaPersonaje > 0)
    {
      vidaPersonaje=ControladorPuntos.vidaPersonaje;
      vidaPersonaje--;
      uiManager.RestaCorazon(vidaPersonaje);
      ControladorPuntos.instance.RestaVida();
      if (vidaPersonaje == 0)
      {
        anim.SetTrigger("Muere");
        Invoke(nameof(MuertePersonaje), 1f);
        audioSourceMuerte.Play();
        MuerteJugador?.Invoke(this, EventArgs.Empty);

      }
    }
  }
  public void SumarVida()
  {
    if (vidaPersonaje < 3)
    {
      vidaPersonaje++;
      ControladorPuntos.instance.SumaVida();
      uiManager.SumarCorazon(vidaPersonaje);
    }
  }
  public void SumarVida2()
  {
    if (vidaPersonaje < 2)
    {
      vidaPersonaje += 2;
      ControladorPuntos.instance.SumaVida2();
      uiManager.SumarCorazon2(vidaPersonaje);
    }
    else if (vidaPersonaje == 2)
    {
      vidaPersonaje++;
      uiManager.SumarCorazon(vidaPersonaje);
    }
  }
  private void MuertePersonaje()
  {
    Destroy(this.gameObject);
  }
  public void VelocidadPersonaje()
  {
    velocidad += (velocidad * 0.25f);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Verificar si el objeto que colisiona es el borde superior
    if (collision.CompareTag("BordeArriba"))
    {
      Vector3 newPosition = new Vector3(0.54f, -9.67f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    if (collision.CompareTag("BordeAbajo"))
    {
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
      
    }
    if (collision.CompareTag("BordeIzquierda"))
    {
      Vector3 newPosition = new Vector3(18.09f, -0.09f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    if (collision.CompareTag("BordeDerechaNivel1"))
    {
      Vector3 newPosition = new Vector3(-29.2f, -2.59f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    if (collision.CompareTag("BordeInferiorNivel2"))
    {
      Vector3 newPosition = new Vector3(-17.86f, 5.47f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    if (collision.CompareTag("SuperiorIzq"))
    {
      Vector3 newPosition = new Vector3(-0.13f, -5.62f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    if (collision.CompareTag("BordeInferiorNivel3"))
    {
      Vector3 newPosition = new Vector3(0.62f, 4.97f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    if (collision.CompareTag("BordeSuperior"))
    {
      Vector3 newPosition = new Vector3(-1.13f, -5.13f, 0f);
      PlayerPrefs.SetFloat("PlayerPosX", newPosition.x);
      PlayerPrefs.SetFloat("PlayerPosY", newPosition.y);
      PlayerPrefs.SetFloat("PlayerPosZ", newPosition.z);
      // Cambiar a la otra escena
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
  }
  
}

