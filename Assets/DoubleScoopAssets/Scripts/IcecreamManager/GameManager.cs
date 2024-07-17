using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public TextMeshProUGUI orderDisplay;
    public TextMeshProUGUI orderCorrect;
    private void Start()
    {
        orderCreationScript = GetComponent<OrderCreation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        orderDisplay.text = UpdateOrderText(orderCreationScript.orderNumber);
        if (orderCompleted){
            // Create New Order
            orderCreationScript.orderNumber = orderCreationScript.CreateTicketNumber();

            if (orderIsMatched) // We completed the order correctly - Great!
            {
                //audioManager.PlaySound("OrderSuccess");
                AudioManager.instance.PlaySound("OrderSuccess");
                orderCorrect.text = "Last order was Correct!\nIcecream Order:";
                
            }
            else // We did not complete the order correctly - Oops!
            {
                //audioManager.PlaySound("OrderFailed");
                AudioManager.instance.PlaySound("OrderFailed");
                orderCorrect.text = "Last order was Wrong!\nIcecream Order:";
            }
            // TODO: Delete previous order ticket printed from (machine/screen/etc).

            // TODO: Display order ticket at (machine/screen/etc).
            orderCompleted = false; //Reset
        }
    }

    string UpdateOrderText(int orderNumber)
    {
        int firstScoop = 0;
        int secondScoop = 0;
        int thirdScoop = 0;

        int length = orderNumber.ToString().Length;
        if (length >= 1) firstScoop = orderNumber % 10;
        if (length >= 2) secondScoop = (orderNumber / 10) % 10;
        if (length >= 3) thirdScoop = (orderNumber / 100) % 10;

        switch (length)
        {
            case 1: return GetNumberAsText(firstScoop); 
            case 2: return GetNumberAsText(firstScoop) + ", " + GetNumberAsText(secondScoop);
            case 3: return GetNumberAsText(firstScoop) + ", " + GetNumberAsText(secondScoop) + ", " + GetNumberAsText(thirdScoop);
        }
        return "Order not readable";
    }

    string GetNumberAsText(int number)
    {
        switch (number){ 
            case 1:
                return "Velocity Vanilla";
            case 2:
                return "Fudge Fusion";
            case 3:
                return "Surge Strawberry";
            case 4:
                return "Prime Pistachio";
            case 5:
                return "Rasberry Swirl";
            case 6:
                return "Antifreeze Blue";
            case 7:
                return "Nebula";
            case 8:
                return "Orange Paint";
            case 9:
                return "Depleted Uranium";
        }
        return "ERROR";
    }
}
