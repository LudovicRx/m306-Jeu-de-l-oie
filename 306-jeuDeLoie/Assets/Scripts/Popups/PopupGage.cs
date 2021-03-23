using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGage : Popup
{
    public Button button;
    public Text titreGage;
    public Text descriptionGage;


    public void AfficherGage(Gage gage)
    {
        AfficherPopup();
        titreGage.text = "Titre temporaire";
        descriptionGage.text = gage.description;
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(MasquerPopup);
    }
}
