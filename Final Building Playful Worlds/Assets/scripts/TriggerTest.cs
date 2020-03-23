using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    public GameObject plankje;
    private Renderer materiaal;
    public GameObject Cylinder;

    // Start is called before the first frame update
    void Start()
    {
        materiaal = Cylinder.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        if (plankje.tag == "trigger"){

            materiaal.material.color = Color.green;      
        
        }
    }

    void OnTriggerExit()
    {
        if (plankje.tag == "trigger")
        {

            materiaal.material.color = Color.white;

        }
    }
}
