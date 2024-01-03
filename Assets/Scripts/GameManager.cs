using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject jaje;
    public Transform mjestoStvaranja;
    Vector3 pozicijaStvaranja;
    bool krajIgre = false;
    public float brzinaStvaranja;

    public float maksimalnaPozicija;
    int bodovi = 0;

    public Text bodoviText;
    public GameObject startUI;
    public GameObject krajIgreUI;
    public GameObject kos;

    private void Awake()
    {
        //Postavlja instancu na trenutni objekt.
        instance = this;
    }
    void Start()
    {
        //Postavlja se početna pozicija stvaranja jaja.
        pozicijaStvaranja = mjestoStvaranja.position;
    }
    void PozicijaStvaranjaJaja()
    {
        //Metoda koja postavlja poziciju stvaranja jaja na slučajnu poziciju unutar maksimalne pozicije.
        float slucajnaPozicijaX = Random.Range(-maksimalnaPozicija, maksimalnaPozicija);
        pozicijaStvaranja.x = slucajnaPozicijaX;
        
        //Omogućava stvaranje kopije objekta na određenoj poziciji pod istom rotacijom
        Instantiate(jaje, pozicijaStvaranja, Quaternion.identity);
    }

    IEnumerator stvaranjeJaja()
    {
        //Redovito stvaranje jaja određenom brzinom.
        while (true)
        {
            yield return new WaitForSeconds(brzinaStvaranja);
            PozicijaStvaranjaJaja();
        }
    }

    public void DodajBod()
    {
        //Metoda koja dodaje bod igraču ako igra još nije završila.
        if (krajIgre == false)
        {
            bodovi++;
            bodoviText.text = bodovi.ToString();
        }
    }


    public void StartIgre()
    {
        //Metoda koja pokreće igru, sakriva početni ekran, prikazuje bodove i pokreće coroutine za stvaranje jaja.
        startUI.SetActive(false);
        bodoviText.gameObject.SetActive(true);
        kos.SetActive(true);
        StartCoroutine("stvaranjeJaja");
    }

    public void KrajIgre()
    {
        //Metoda koja označava kraj igre, sakriva kos, zaustavlja coroutine stvaranja jaja i prikazuje ekran kraja igre.
        krajIgre = true;
        kos.SetActive(false);
        StopCoroutine("stvaranjeJaja");
        krajIgreUI.SetActive(true);
    }
    
    public void PokreniPonovo()
    {
        //Metoda koja ponovno pokreće trenutnu scenu (igru).
        SceneManager.LoadScene(0);
    }
}
