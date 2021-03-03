using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    private long idCase;

    private GameObject gameObject;
    private List<Gage> gage = new List<Gage>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Case(long InIdCase, GameObject InGameObject)
    {
        idCase = InIdCase;
        gameObject = InGameObject;
    }
}
