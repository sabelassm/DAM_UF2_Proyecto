using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
   [SerializeField] private GameObject tienda;
   private AudioSource audioSource;
   [SerializeField] private AudioSource audioSourceFondo;
  
  private void Awake()
  {
      audioSource = GetComponent<AudioSource>();
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
      
      tienda.SetActive(true);
      audioSourceFondo.Stop();
      audioSource.Play();
  }
  public void PararAudio()
  {
      audioSource.Stop();
      audioSourceFondo.Play();
  }
  
}
