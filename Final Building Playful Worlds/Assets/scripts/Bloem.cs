using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloem : MonoBehaviour
{
    public ParticleSystem bloemParticles;
    public bool opgepakt = false;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (opgepakt == true)
        {
            bloemParticles.Stop();
            Debug.Log("Stop de particles");
        }
    }
}
