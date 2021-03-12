using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody myRB; //RIGIDBODY COMPONENT OF THIS GAMEOBJECT
    public float SpeedMultiplier; //THE SPEED USED TO CALCULATE THE LAUNCH POWER OF THE BALL

    // Start is called before the first frame update
    void Start()
    {      
        myRB = GetComponent<Rigidbody>(); // SET REFERENCE TO THIS OBEJCT'S RIGIDBODY
        StartCoroutine(DestroyBall()); //CALL COROUTINE TO DESTROY THE BALL
        MoveBall();
    }

    private void MoveBall()
    {
        //AFTER BEING INSTANTIATED THE BALL IS LAUNCHED IN THE TARGET DIRECTION
        myRB.AddForce(transform.forward * 6f * SpeedMultiplier);
    }

    private IEnumerator DestroyBall()
    {
        //DESTROY THE BALL GAMEOBJECT AFTER A SET AMOUNT OF SECONDS 
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
