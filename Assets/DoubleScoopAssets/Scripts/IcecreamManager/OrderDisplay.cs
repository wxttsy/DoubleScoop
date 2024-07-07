using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDisplay : MonoBehaviour
{
    public GameManager Manager;

    private IceCreamScoop firstScoop;
    private IceCreamScoop secondScoop;
    private IceCreamScoop thirdScoop;
    private TOPPING topping;

    [SerializeField]
    private GameObject orderDisplayDevice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayOrder(/*Order order*/)
    {
        //take order values and convert to Ice Cream Flavours
        //firstScoop = order.baseScoop;
        //secondScoop = order.middleScoop;
        //thirdScoop = order.topScoop;
        //topping = order.topping;

        //orderDisplayDevice.GetComponentInChildren<Shader>().setProperty(iceCreamColour, firstScoop);
    }
}
