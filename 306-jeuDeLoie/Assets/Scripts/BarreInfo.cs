using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreInfo : MonoBehaviour
{
    public Text tour;
    public Text resultatDes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTour(Joueur joueurActuel)
    {
        tour.text = $"Tour de {joueurActuel.nom}";
        resultatDes.text = $"Résultat des dés : {joueurActuel.resultatDes}";
    }
}
