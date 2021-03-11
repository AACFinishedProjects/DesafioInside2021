using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //GAMEOBJECTS
    public GameObject Ball; //BALL PREFAB
    public GameObject Cone; //SPAWN PIVOT FOR THE BALL PREFAB
    public Slider PowerSlider; //SLIDER HANDLE FOR THE POWER VALUE
    public Slider AngleSlider; //SLIDER HANDLE FOR THE ANGLE VALUE
    public Image CDGray; //COOLDOWN SPRITE

    //VARIABLES
    public float IncCDTime; //TICK TO DECREASE COOLDOWN TIMER
    public float CDDecrease; //AMOUNT TO DECREASE PER TICK
    public bool canStartTimer; //ALLOWS THE CODE TO DECREASE 

    // Update is called once per frame
    void Update()
    {
        RotatePivot();
    }

    public void StartCD()
    {
        //ALLOWS COROUTINE TO DECREASE THE FILL AMOUNT OF THE COOLDOWN SPRITE
        if (canStartTimer == true)
        {
            StartCoroutine(FillCD());
            canStartTimer = false;
            CDGray.enabled = true;
        }
    }

    public IEnumerator FillCD()
    {
        //IF COOLDOWN IS COMPLETE FILL THE COOLDOWN SPRITE AND DISABLE IT ELSE DECREASE THE FILL AMOUNT 
        if (CDGray.fillAmount <= 1f || CDGray.fillAmount > 0f)
        {
            yield return new WaitForSeconds(IncCDTime);
            CDGray.fillAmount -= CDDecrease;
            if (CDGray.fillAmount == 0f)
            {
                CDGray.fillAmount = 1f;
                CDGray.enabled = false;
                canStartTimer = true;
            }
            else
            {
                StartCoroutine(FillCD());
            }
        }
    }

    public void ThrowBall()
    {
        if (canStartTimer == true)
        {
            //INSTANTIATE BALL PREFAB, SET ITS PARENT TO BE THIS GAMEOBJECT AND SET SPEED BASED ON THE POWER SLIDER VALUE
            var newBall = Instantiate(Ball, Cone.transform.position, transform.rotation);
            newBall.transform.parent = transform.parent;
            newBall.GetComponent<BallController>().SpeedMultiplier = PowerSlider.value;
        }
    }

    private void RotatePivot()
    {
        //CONTROL THE TARGET ANGLE BASED ON THE ANGLE SLIDER VALUE
        transform.eulerAngles = new Vector3(-180 + AngleSlider.value * 75f, 0, 0);
    }

}
