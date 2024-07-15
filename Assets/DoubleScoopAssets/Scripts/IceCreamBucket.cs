using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamBucket : MonoBehaviour
{
    public GameObject scoopToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if(other.gameObject.CompareTag("Scooper"))
        {
            Debug.Log("Scooper Detected");
            if(other.GetComponentInChildren<IceCreamScooper>().inHand == true && other.GetComponentInChildren<IceCreamScooper>().hasScoop == false)
            {
                Debug.Log("Preparing To Scoop");
                other.GetComponentInChildren<IceCreamScooper>().ScoopIceCream(scoopToSpawn);
            }
        }
    }

    
}
