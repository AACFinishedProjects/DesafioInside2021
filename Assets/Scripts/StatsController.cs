using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    //GAMEOBJECTS
    public TextMeshProUGUI Points; //TEXT OBJECT FOR THE POINTS
    public TextMeshProUGUI Counter; //TEXT OBJECT FOR THE THROWS
    public TextMeshProUGUI Timer; //TEXT OBJECT FOR THE TIME THAT HAS PASSED

    //VARIABLES
    public float pointsAmount; //CURRENT AMOUNT OF POINTS
    public float counterAmount; //CURRENT AMOUNT OF THROWS
    public float timePassed; //CURRENT TIME

    // Update is called once per frame
    void Update()
    {
        //UPDATE TEXT TO THE CURRENT AMOUNT OF POINTS
        if (pointsAmount > 1 || pointsAmount == 0)
        {
            Points.text = pointsAmount.ToString() + " POINTS";
        }
        else
        {
            Points.text = pointsAmount.ToString() + " POINT";
        }

        //UPDATE TEXT TO THE CURRENT AMOUNT OF THROWS
        if (counterAmount > 1 || counterAmount == 0)
        {
            Counter.text = counterAmount.ToString() + " THROWS";
        }
        else
        {
            Counter.text = counterAmount.ToString() + " THROW";
        }
        
        //TIMER SET TO BE IN MINUTES AND SECONDS
        timePassed += Time.deltaTime;

        float minutes = Mathf.FloorToInt(timePassed / 60);
        float seconds = Mathf.FloorToInt(timePassed % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void IncreasePoints()
    {
        pointsAmount += 10;
    }

    public void IncreaseCounter()
    {
        counterAmount++;
    }
}
