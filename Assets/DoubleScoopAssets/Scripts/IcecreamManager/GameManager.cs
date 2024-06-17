using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// *   On order completed - move snowman to next in queue.
/// *   Create new order.
/// *   Reset cone.
/// *   Delete old ticket - create new ticket with new order.
/// </summary>
public enum ICECREAM
{
    NONE,
    VANILLA,
    CHOCOLATE,
    STRAWBERRY,
    PISTACHIO,
    RASPBERRY_SWIRL,
    PIZZA,
    NEBULA,
    ORANGE_PAINT,
    DEPLETED_URANIUM
}



public class GameManager : MonoBehaviour
{
    public OrderCreation orderCreationScript; // Holds the order number we will use to cross reference with the cone.
    private bool orderCompleted = false; // TODO: Should be toggled to true when handing over cone to snowman.

    // Update is called once per frame
    void Update()
    {
        if (orderCompleted){
            // Create New Order
            orderCreationScript.orderNumber = orderCreationScript.CreateOrderNumber();

            // TODO: Delete previous order ticket printed from machine.

            // TODO: Create new order ticket at machine.

            orderCompleted = false;
        }
    }
}
