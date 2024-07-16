using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class IceCreamScooper : MonoBehaviour
{
    [SerializeField]
    Transform ScoopLocation;

    private GameObject scoopOfIcecream;


    public bool inHand;
    public bool hasScoop;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ScoopIceCream(GameObject iceCreamScoop )
    {
        Debug.Log("Scooping");
        scoopOfIcecream = Instantiate(iceCreamScoop, new Vector3(ScoopLocation.position.x, ScoopLocation.position.y, ScoopLocation.position.z), Quaternion.identity, ScoopLocation.GetComponentInParent<IceCreamScooper>().gameObject.transform);
        scoopOfIcecream.GetComponent<IceCreamScoop>().scooper = this;
        hasScoop = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        DropIceCream();
    }

    public void DropIceCream()
    {
        if(scoopOfIcecream != null)
        {
            hasScoop = false;
            scoopOfIcecream.transform.SetParent(null);
            Destroy(scoopOfIcecream);
            /*
            Rigidbody rb = scoopOfIcecream.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = false;*/
            
        }
    }
}
