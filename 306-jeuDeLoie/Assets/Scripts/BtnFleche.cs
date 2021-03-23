using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFleche : MonoBehaviour
{
    public GameObject configurationPartie;
    private bool direction;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(configurationPartie).GetComponent<ConfigurationPartie>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        ChangerConfiguration();
    }

    public void ChangerConfiguration()
    {
        //quand on clique sur une flèche, enregistrer les changement du personnage actuel
        configuration.GetComponent<ConfigurationPartie>().MettreAJourJoueur();
        //puis passer au personnage suivant
        configuration.GetComponent<ConfigurationPartie>().ChangerIdJoueur(direction);
    }
}
