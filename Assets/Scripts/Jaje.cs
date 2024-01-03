using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaje : MonoBehaviour
{
    //Predstavlja granicu y koordinate na kojoj igrač gubi bodove
    public float izgubljeniBod = -6f;
    
    void Update()
    {
        //Provjera da li je jaje palo ispod granice definirane s varijablom izgubljeniBod
        if(transform.position.y < izgubljeniBod)
        {
            //Pokreće metodu KrajIgre u skripti GameManager koja će pokazati GameOver panel
            GameManager.instance.KrajIgre();
            
            //Obrisati će objekt jajeta kada prijeđe zadanu granicu
            Destroy(gameObject);
        }
    }

    //Sudar objekata
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Provjerava da li objekt s kojim jaje sudarilo ima tag "UnutarKosa".
        if(collision.tag == "UnutarKosa")
        {
            //Pokreće metodu DodajBod u skripti GameManager koja će povećati bod za 1.
            GameManager.instance.DodajBod();
            
            //Uništava objekt jajeta nakon što se je sudario s objektom koji ima tag "UnutarKosa".
            Destroy(gameObject);
        }
    }
}

