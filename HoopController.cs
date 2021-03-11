using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    //GAMEOBJECTS
    public GameObject PivotA; //CLOSEST POSITION REFERENCE
    public GameObject PivotB; //FURTHEST POSITION REFERENCE
    public GameObject ScoreParticle; //PARTICLE TO INSTANTIATE WHEN SCORING
    public GameObject PointPrefab; //TEXT TO INSTANTIATE WHEN SCORING

    private void ChangeHoopPosition()
    {
        //CHOOSE A RANDOM POSITION BETWEEN PIVOTS TO SET THE HOOP
        transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(PivotA.transform.position.z, PivotB.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        //CHECK IF THE BALL TOUCHED THE HOOP AND IS ABOVE ITS POSITION
        if (other.gameObject.CompareTag("Ball") && other.gameObject.transform.position.y > transform.position.y)
        {
            Instantiate(ScoreParticle, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
            ChangeHoopPosition();
            GameObject.FindGameObjectWithTag("UIHolder").GetComponent<StatsController>().IncreasePoints();
            GameObject.FindGameObjectWithTag("PointsHolder").GetComponent<Animation>().Play("MoveUp"); //PLAY POINTS ANIMATION ABOVE PLAYER
        }
    }
}
