using System.Collections;
using UnityEngine;

public class MovimientoOrco : MonoBehaviour
{

    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float tiempoEspera;
    [SerializeField] private float velocidadMovimiento;
    private bool esperando;
    private int indicePuntoActual;

    private Animator anim;
    [SerializeField] AudioSource audioSource;
    private void Start()
    {
        Debug.Log("Start - Animator: " + anim);
        anim = GetComponentInChildren<Animator>();
        Debug.Log("After GetComponent - Animator: " + anim);
       

        if (anim == null)
        {
            Debug.LogError("El componente Animator no está asignado en MovimientoOrco.");
        }
    }
    public void Update()
    {
        if (transform.position != puntosMovimiento[indicePuntoActual].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[indicePuntoActual].position,
            velocidadMovimiento * Time.deltaTime);
        }
        else if (!esperando)
        {
            StartCoroutine(Esperar());
        }

    }
    //corrutina que hace que nuestro orco espere un tiempo determinado
    //cuando llega a un punto de movimiento
    IEnumerator Esperar()
    {
        esperando = true;
        yield return new WaitForSeconds(tiempoEspera);
        indicePuntoActual++;
        if (indicePuntoActual == puntosMovimiento.Length)
        {
            indicePuntoActual = 0;
        }
        esperando = false;
        Flip();
    }


    //cuando el personaje traspasa el boxCollider del orco
    //este reproduce la animacion de ataque y le daña

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("NoAtaca");

        if (other != null && other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Ataca");
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
    private void Flip()
    {
        if (transform.position.x > puntosMovimiento[indicePuntoActual].position.x)
        {

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
