using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// *   Function to create random order.
/// *   Currently only includes ice-cream, toppings not supported.
/// *   Compare order to cone number./Toggle order completed in game manager.
/// </summary>


public class OrderCreation : MonoBehaviour
{
    public int orderNumber = 0;
    public int toppingNumber = 0;
    public int maxScoops = 4;
    void Update()
    {
        orderNumber = CreateOrderNumber();
    }

    public int CreateOrderNumber() // Returns a 1-3 digit int which is used as the snowman's order number.
    {
        Debug.Log("==============================================NEW ICECREAM ORDER");
        int order = 0;
        float currentScoop = 0f;
        float rate = 10f;

        // Create icecream order.
        int amountOfScoops = Random.Range(1, maxScoops);
        for (int i = 0; i < amountOfScoops; i++)
        {
            int thisScoop;
            // Ensure the first scoop in the order is always atleast 1.
            if (currentScoop == 0){ thisScoop = Random.Range(1, 9); } 
            else { thisScoop = Random.Range(0, 9); }
            if (thisScoop == 0)
            {
                Debug.Log("Exit rolled 0");
                break;
            }
            Debug.Log(thisScoop + "This SCOOP = " + currentScoop); //Print the scoop number in debug log.
            order += thisScoop * (int)Mathf.Pow(rate, currentScoop);
            currentScoop++;
        }
        Debug.Log("RETURNED ORDER NUMBER============================================" + order);
        CreateToppingForCone();
        return order;
    }

    public void CreateToppingForCone()
    {
        toppingNumber = Random.Range(0, 4);
        Debug.Log(toppingNumber);
    }
}
