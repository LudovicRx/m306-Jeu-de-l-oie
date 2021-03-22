using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    /// <summary>
    /// Affiche le popup
    /// </summary>
    public void AfficherPopup()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Masque le popup
    /// </summary>
    public void MasquerPopup()
    {
        this.gameObject.SetActive(false);
    }
}
