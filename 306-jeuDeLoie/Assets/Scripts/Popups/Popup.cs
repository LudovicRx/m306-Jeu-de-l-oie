using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    /// <summary>
    /// Définit si le popup est ouvert
    /// </summary>
    private bool isOpen = false;

    /// <summary>
    /// Définit si le popup est ouvert
    /// </summary>
    /// <value>True si ouvert, sinon false</value>
    public bool IsOpen { get => isOpen; }

    /// <summary>
    /// Affiche le popup
    /// </summary>
    public void AfficherPopup()
    {
        ChangerEtat(true);
    }

    /// <summary>
    /// Masque le popup
    /// </summary>
    public void MasquerPopup()
    {
        ChangerEtat(false);
    }

    /// <summary>
    /// Change l'état du poup
    /// </summary>
    /// <param name="etat">True pour ouvrir, false pour fermer</param>
    private void ChangerEtat(bool etat)
    {
        this.gameObject.SetActive(etat);
        isOpen = etat;
    }
}
