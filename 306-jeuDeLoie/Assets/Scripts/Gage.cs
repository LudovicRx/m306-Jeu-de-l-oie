using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gage : MonoBehaviour
{
    public static UnityEngine.Color bleu = new UnityEngine.Color(60f / 255f , 128f / 255f, 248f / 255f, 255f /255f);
    public static UnityEngine.Color vert = new UnityEngine.Color(1f / 255f , 255f / 255f, 96f / 255f, 255f /255f);
    public static UnityEngine.Color brun = new UnityEngine.Color(60f / 255f , 128f / 255f, 248f / 255f, 255f /255f);
    public static UnityEngine.Color orange = new UnityEngine.Color(255f / 255f , 213f / 255f, 64f / 255f, 255f /255f);

    public static List<Gage> gages = new List<Gage>() {
        new Gage("Fait un bras de fer avec la personne qui est à ta droite", bleu),
        new Gage("Parle comme Yoda pendant les trois prochain tours", Color.red),
        new Gage("Joue à ni oui ni non avec la personne à ta gauche, celui qui perd fait 10 pompes", vert),
        new Gage("Ne parle plus pendant trois tours", Color.magenta),
        new Gage("Fait un combat de regard avec la personne qui est à ta droite", Color.yellow)
        
    };
    public string description;
    public Color color;

    public Gage() : this("Sample Gage", Color.black){} 
    public Gage(string InDescription) : this(InDescription, Color.blue) {}
    public Gage(string InDescription, Color InColor){
        description = InDescription;
        color = InColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
