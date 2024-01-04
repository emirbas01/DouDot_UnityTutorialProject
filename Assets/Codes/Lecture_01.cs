using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lecture_01 : MonoBehaviour
{
    public int para = 100;
    public int canHakki = 3;
    public float can = 100f;
    public bool paraDegistiMi;

    public string nickname;

    public GameObject mevcutObje;

    public Vector3 newPosition;
        
    void Start()
    {
        canHakki = 3;
        mevcutObje.GetComponent<CharacterMovement>().speed = 10;

        
        newPosition = new Vector3(0, 0, 0); 
    }
    void Update() 
    {
        transform.Translate(newPosition);
    }
    public void ParaDegeriniDegistir(int paraDegeri, bool paraDegisti)
    {
        para = paraDegeri;
        paraDegistiMi = paraDegisti;
    }
    void IsimDegistir(GameObject obje, string isim)
    {
        obje.name = isim;
    }
}
