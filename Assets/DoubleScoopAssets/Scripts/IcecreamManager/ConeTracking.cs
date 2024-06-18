using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTracking : MonoBehaviour
{
    public int coneTrackingNumber = 0;
    public int toppingTrackingNumber = 0;
    [SerializeField] private int currentScoops = 0;
    [SerializeField] private int maxScoopsForCone = 3;

    private void Start()
    {
        AddIcecreamFlavor(ICECREAM.ANTIFREEZE_BLUE);
        AddIcecreamFlavor(ICECREAM.VELOCITY_VANILLA);
        AddIcecreamFlavor(ICECREAM.VELOCITY_VANILLA);
        AddToppingFlavor(TOPPING.TOPPING3);
        Debug.Log(coneTrackingNumber);
        Debug.Log(toppingTrackingNumber);
    }
    public void AddIcecreamFlavor(ICECREAM flavor) // Call this when adding a Scoop of icecream to the cone.
    {
        if (currentScoops >= maxScoopsForCone) { return; } // Do not allow the player to add more scoops if maxscoops have already been added.
        float rate = 10f;
        coneTrackingNumber += (int)flavor * (int)Mathf.Pow(rate, currentScoops);
        currentScoops++;

        //TODO: Parent the scoop to the cone visually.
    }

    public void AddToppingFlavor(TOPPING topping) // Call this when adding a topping to the cone.
    {
        if (toppingTrackingNumber > 0) { return; } // Do not add topping if we already have one.
        toppingTrackingNumber = (int)topping;

        //TODO: Add topping visuals to the cone.
    }

    public void CompareAgainstOrder() // Call this when giving a cone to a snowman to see if it was a match.
    {
        // Find OrderCreation object to get the OrderCreation.cs which holds our current order number.
        int orderNumber = 0;
        int toppingNumber = 0;
        // Return true if this cone's Tracking number + topping Tracking number match the order.
        bool isMatch = coneTrackingNumber == orderNumber && toppingTrackingNumber == toppingNumber;

        //TODO: GameManager.cs orderIsMatched == isMatch

        // TODO: Toggle GameManager.cs orderCompleted bool to be true so a new order can be made.
    }
}
