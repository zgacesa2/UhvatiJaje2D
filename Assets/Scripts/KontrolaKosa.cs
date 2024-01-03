using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaKosa : MonoBehaviour
{
    //Deklaracija varijabli
    Vector3 pozicijaDodira;
    public float brzinaKretanja = 0.2f;
    public float limitPoX;
    void Update()
    {
        //Provjera da li je pritisnuta lijeva tipka miša.
        if (Input.GetMouseButton(0))
        {
            //Pozicija dodira miša
            pozicijaDodira = Camera.main.ScreenToWorldPoint ( Input.mousePosition ) ;
            
            //Trenutna pozicija objekta
            Vector3 novaPozicija = transform.position; 
            
            //Postavljanje nove pozicije dodira miša.
            novaPozicija.x = pozicijaDodira.x;
            
            //Ograničavanje x koordinate na određeni raspon kako bi spriječili objekt da izlazi iz zadanih granica.
            novaPozicija.x = Mathf.Clamp(novaPozicija.x, -limitPoX, limitPoX);
            
            /*Korištenje linearne interpolacije (Lerp) za postupno pomicanje objekta
            prema novoj poziciji, uzimajući u obzir brzinu kretanja.*/
            transform.position = Vector3.Lerp(transform.position, novaPozicija, brzinaKretanja);
        }
    }
}

