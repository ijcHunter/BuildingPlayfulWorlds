using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
   

    private float rotY;

    void Start()
    {

    }


    void Update()
    {
        rotY -= Input.GetAxis("Mouse Y");

        this.transform.position = new Vector3(player.position.x, player.position.y + 0.3f, player.position.z);
        this.transform.rotation = player.rotation;

        this.transform.rotation = Quaternion.Euler(rotY, player.rotation.eulerAngles.y, player.rotation.eulerAngles.z);
        
    }
}