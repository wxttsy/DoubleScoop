using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// *   Function to create random order.
/// *   Compare order to cone number.
/// *   Toggle order completed in game manager.
/// </summary>


public class OrderCreation : MonoBehaviour
{
    public int orderNumber = 0;
    private int maxScoops = 3;
    private int maxToppingsCount = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CreateOrderNumber()
    {
        int currentScoop = 0;
        for (int i = 0; i < 4; i++)
        {
            int thisScoop = Random.Range(0, 9);
            Debug.Log(thisScoop); //Print the scoop number in debug log.
            orderNumber += thisScoop * currentScoop * 10;
            Debug.Log(orderNumber + "Current order number");
        }

        return 0;
    }
}
