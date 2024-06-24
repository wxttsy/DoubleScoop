using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class IceCreamScooper : MonoBehaviour
{
    [SerializeField]
    Transform ScoopLocation;

    public bool inHand;
    public bool canScoop;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ScoopIceCream(GameObject iceCreamScoop )
    {
        Debug.Log("Scooping");
        Instantiate(iceCreamScoop, new Vector3(ScoopLocation.position.x, ScoopLocation.position.y, ScoopLocation.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        inHand = true;
    }

    public void OnRelease()
    {
        inHand = false;
    }
}
