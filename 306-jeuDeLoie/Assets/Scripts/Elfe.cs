using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elfe : Espece
{
    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SeDeplacer()
    {

    }

    public override void Action(Joueur joueurActuel)
    {
        float result = rnd.Next(1, 101);
        result = Mathf.Round(result / 10f);
        if (result <= 50)
        {
            joueurActuel.SeDeplacer(1);
        }
    }
}
