using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnElfe : MonoBehaviour
{
    public GameObject camera;
    public GameObject fondPageConfig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
       //Changer la race du personnage en train d'être configuré

       //nbJoueurs = "remplacer par textarea.text";

       //créer la partie (générer le bon nombre de joueurs)
       //CreerPartie();

       //Aller sur la page pour personnaliser les personnages
       camera.GetComponent<Transform>().position = new Vector3(fondPageConfig.transform.position.x, fondPageConfig.transform.position.y, 60);
    }
}
