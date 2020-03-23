using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLicht : MonoBehaviour
{
    public GameObject bloem;
    public Light lightToSwitch = null;

    public void OnTriggerEnter(Collider other)
    {
        lightToSwitch.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        lightToSwitch.enabled = false;
    }
}
