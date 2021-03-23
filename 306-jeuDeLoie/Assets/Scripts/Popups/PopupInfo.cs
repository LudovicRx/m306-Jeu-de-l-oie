using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Popup pour les informations du jeu
/// </summary>
public class PopupInfo : Popup
{
    /// <summary>
    /// Bouton pour fermer le popup
    /// </summary>
    public Button button;
    /// <summary>
    /// Titre de la popup
    /// </summary>
    public Text titre;
    /// <summary>
    /// Descriptiom du popup
    /// </summary>
    public Text description;


    /// <summary>
    /// Affiche la popup info
    /// </summary>
    /// <param name="InTitre">Titre de la popup</param>
    /// <param name="InDescription">Description</param>
    public void AfficherPopupInfo(string InTitre, string InDescription)
    {
        AfficherPopup();
        titre.text = InTitre;
        description.text = InDescription;
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(MasquerPopup);
    }
}
