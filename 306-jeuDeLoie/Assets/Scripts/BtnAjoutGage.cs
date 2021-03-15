using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAjoutGage : MonoBehaviour
{
    public GameObject camera;
    public GameObject gages;
    public GameObject fondGages;
    // Start is called before the first frame update
    void Start()
    {
         gages.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnMouseDown()
    {
       camera.GetComponent<Transform>().position = new Vector3(fondGages.transform.position.x, fondGages.transform.position.y,60);
    }
}
