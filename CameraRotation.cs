using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed; //THE ROTATION SPEED OF THE CAMERA HOLDER
    public bool canRotate; //ALLOWS THE CAMERA HOLDER TO ROTATE

    // Update is called once per frame  
    void Update()
    {
        if (canRotate == true)
        {
            //ROTATE CAMERA AROUND ARENA
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        }
    }

    public void StopRotation()
    {
        //STOP ROTATION AND RESET POSITION AND TIMER
        canRotate = false;
        transform.eulerAngles = new Vector3(0, 180, 0);
        GameObject.FindGameObjectWithTag("UIHolder").GetComponent<StatsController>().timePassed = 0f;
    }
}
