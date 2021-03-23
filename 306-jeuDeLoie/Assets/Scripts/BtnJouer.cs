using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnJouer : MonoBehaviour
{
     private string texte;

    public GameObject camera;
    public GameObject creerPartie;
    public GameObject fondCreerPartie;


    // Start is called before the first frame update
    void Start()
    {
         creerPartie.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jouer()
    {

    }

    public void OnMouseDown()
    {
       //aller sur la page pour créer une partie (choisir le nombre de joueurs)
       camera.GetComponent<Transform>().position = new Vector3(fondCreerPartie.transform.position.x, fondCreerPartie.transform.position.y,60);
    }
}
