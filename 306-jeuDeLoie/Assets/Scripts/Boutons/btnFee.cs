using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFee : MonoBehaviour
{
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnMouseDown()
    {
        button.GetComponent<Renderer>().material.color = Color.green;
        
    }
}
