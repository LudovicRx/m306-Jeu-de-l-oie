using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Popup de la fin de la partie
/// </summary>
public class PopupFinPartie : Popup
{
    /// <summary>
    /// Bouton pour relancer la partie
    /// </summary>
    public Button btnRejouer;
    /// <summary>
    /// Bouton pour retourner au menu principal
    /// </summary>
    public Button btnMenuPrincipal;
    /// <summary>
    /// Text qui affiche le nom du joueur qui gagne
    /// </summary>
    public Text nomGagnant;

    /// <summary>
    /// Affiche le popup de la fin
    /// </summary>
    /// <param name="joueurGagnant">Joueur qui a gagné</param>
    public void AfficherPopUpFin(Joueur joueurGagnant)
    {
        AfficherPopup();
        nomGagnant.text = joueurGagnant.nom;
    }

    // Start is called before the first frame update
    void Start()
    {
        btnRejouer.onClick.AddListener(MasquerPopup);
    }
}
