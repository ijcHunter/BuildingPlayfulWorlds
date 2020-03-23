
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;

    //elk frame
    void Update()
    {
       transform.position = player.position; //+ offset; 
    }
}
