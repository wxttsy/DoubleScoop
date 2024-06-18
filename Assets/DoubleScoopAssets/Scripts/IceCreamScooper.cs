using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class IceCreamScooper : MonoBehaviour
{
    [SerializeField]
    GameObject iceCreamScoop;
    [SerializeField]
    GameObject ScoopLocation;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ScoopIceCream()
    {
        Instantiate(iceCreamScoop, ScoopLocation.transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
