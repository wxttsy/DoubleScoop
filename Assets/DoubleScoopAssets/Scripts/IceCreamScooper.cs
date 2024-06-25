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
    public bool hasScoop;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ScoopIceCream(GameObject iceCreamScoop )
    {
        Debug.Log("Scooping");
        Instantiate(iceCreamScoop, new Vector3(ScoopLocation.position.x, ScoopLocation.position.y, ScoopLocation.position.z), Quaternion.identity, ScoopLocation.GetComponentInParent<IceCreamScooper>().gameObject.transform);
        hasScoop = true;
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

    public void Activate()
    {
        if(hasScoop && inHand)
        {
            GameObject scoop = GetComponentInChildren<IceCreamScoop>().gameObject;
            scoop.transform.parent = null;
            scoop.GetComponent<Rigidbody>().isKinematic = false;
            hasScoop = false;
        }
    }
}
