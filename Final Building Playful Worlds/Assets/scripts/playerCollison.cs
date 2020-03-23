
using UnityEngine;

public class playerCollison : MonoBehaviour
{
 
 public playerMovement movement;

 void OnCollisionEnter (Collision collisonInfo)
 {

     if (collisonInfo.collider.tag == "Obstacle"){

        movement.enabled = false; 
     }
 }


}
