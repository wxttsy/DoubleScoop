using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// *   Function to create random order.
/// *   Currently only includes ice-cream, toppings not supported.
/// </summary>


public class OrderCreation : MonoBehaviour
{
    public int orderNumber = 0;
    public int toppingNumber = 0;
    [SerializeField] private int maxScoops = 3; // The max amount of scoops an order will ask for.
    void Start()
    {
        // Init first order.
        orderNumber = CreateTicketNumber();
    }

    public int CreateTicketNumber() // Returns a 1-3 digit int which is used as the snowman's order number. (Also creates the topping number.)
    {
        int order = 0;
        float currentScoop = 0f;
        float rate = 10f;

        // Create icecream order.
        int amountOfScoops = Random.Range(1, maxScoops+1);
        for (int i = 0; i < amountOfScoops; i++){
            int thisScoop;

            // Ensure the first scoop in the order always has a flavor.
            if (currentScoop == 0){ thisScoop = Random.Range(1, 9); } 
            else { thisScoop = Random.Range(0, 9); }

            // End Icecream creation if we have rolled no flavor.
            if (thisScoop == 0) {
                break;
            }
            order += thisScoop * (int)Mathf.Pow(rate, currentScoop);
            currentScoop++;
        }
        CreateToppingForCone();
        return order;
    }

    public void CreateToppingForCone()
    {
        toppingNumber = Random.Range(0, 4);
    }
}
