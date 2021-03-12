using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonObject : MonoBehaviour
{
    public int ID; //ID OF THE GAMEOBJECT

    // Start is called before the first frame update
    void Start()
    {
        //SIMPLE SCRIPT TO DESTROY ANY GAMEOBJECT
        if (ID == 0)
        {
            StartCoroutine(DestroyObject());
        }  
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
   
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
