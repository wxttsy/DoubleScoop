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
    NONE = 0,
    VELOCITY_VANILLA = 1,
    FUDGE_FUSION = 2,
    SURGE_STRAWBERRY = 3,
    PRIME_PISTACHIO = 4,
    RASPBERRY_SWIRL = 5,
    ANTIFREEZE_BLUE = 6,
    NEBULA = 7,
    ORANGE_PAINT = 8,
    DEPLETED_URANIUM = 9
}

public enum TOPPING
{
    NONE = 0,
    TOPPING1 = 1,
    TOPPING2 = 2,
    TOPPING3 = 3,
}

public class GameManager : MonoBehaviour
{
    public Transform snowmanPosition1;
    public Transform snowmanPosition2;
    public Transform snowmanReset;
    [HideInInspector] private OrderCreation orderCreationScript; // Holds the order number we will use to cross reference with the cone.
    [HideInInspector] public bool orderCompleted = false;
    public bool orderIsMatched = false;

    private void Start()
    {
        orderCreationScript = GetComponent<OrderCreation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (orderCompleted){
            // Create New Order
            orderCreationScript.orderNumber = orderCreationScript.CreateTicketNumber();

            if (orderIsMatched) // We completed the order correctly - Great!
            {
                Debug.Log("We gave the snowman the order he wanted!");
            }
            else // We did not complete the order correctly - Oops!
            {
                Debug.Log("Oops, we got the snowmans order wrong.");
            }
            // TODO: Delete previous order ticket printed from (machine/screen/etc).

            // TODO: Display order ticket at (machine/screen/etc).

            orderCompleted = false; //Reset
        }
    }
}
