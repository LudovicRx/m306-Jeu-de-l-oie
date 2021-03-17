using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGage : MonoBehaviour
{
    public Button button;
    public Text TitreGage;
    public Text DescriptionGage;


    public void AfficherGage(Gage gage)
    {
        this.gameObject.SetActive(true);
        TitreGage.text = "Titre temporaire";
        DescriptionGage.text = gage.description;
    }

    public void MasquerGage()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(MasquerGage);
    }
}
