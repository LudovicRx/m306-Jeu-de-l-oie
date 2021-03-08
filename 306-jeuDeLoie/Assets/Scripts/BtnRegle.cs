using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRegle : MonoBehaviour
{

    
    public GameObject camera;
    public GameObject creerPartie;
    public GameObject fondCreerPartie;
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
       camera.GetComponent<Transform>().position = new Vector3(fondCreerPartie.transform.position.x, fondCreerPartie.transform.position.y,60);
    }
}
