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

    /// <summary>
    /// Met à jour les infos dans la barre d'info
    /// </summary>
    /// <param name="joueurActuel">Joueur qui joue</param>
    public void Init(Joueur joueurActuel)
    {
        tour.text = $"Tour de {joueurActuel.nom}";
        resultatDes.text = $"Résultat des dés : x";
    }

    /// <summary>
    /// Met à jour le résultat du dé
    /// </summary>
    /// <param name="joueurActuel">Joueur qui joue</param>
    public void UpdateDe(Joueur joueurActuel)
    {
        resultatDes.text = $"Résultat des dés : {joueurActuel.resultatDes}";
    }
}
