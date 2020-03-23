
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb; // dit is naar refrentie van de rigidbody component

    public float forwardForce = 500;
    public float sidewaysForce = 500;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // gebruik fixed update omdat we physics stuff gebruiken
    // Update is called once per frame
    void FixedUpdate()
    {
      // rb.AddForce(0, 0 ,forwardForce * Time.deltaTime); // adds forward force on the z as
   
        if (Input.GetKey("d")) //player kan naar rechts
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
          
        if (Input.GetKey("a")) //player kan naar links
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w")) //player  kan naar voren
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime,  ForceMode.VelocityChange);
        }

        if (Input.GetKey("s")) //player  kan naar voren
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime,ForceMode.VelocityChange);
        }

         
   
   
    }

}
