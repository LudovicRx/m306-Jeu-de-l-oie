using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRegle : MonoBehaviour
{
    
    public GameObject camera;
    public GameObject regles;
    public GameObject fondRegle;
    // Start is called before the first frame update
    void Start()
    {
         regles.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnMouseDown()
    {
       camera.GetComponent<Transform>().position = new Vector3(fondRegle.transform.position.x, fondRegle.transform.position.y,60);
    }
}
