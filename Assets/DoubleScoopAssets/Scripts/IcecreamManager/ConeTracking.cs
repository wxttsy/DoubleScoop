using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConeTracking : MonoBehaviour
{
    public int coneTrackingNumber = 0;
    public int toppingTrackingNumber = 0;
    private bool coneServed = false;
    [SerializeField] private int currentScoops = 0;
    [SerializeField] private int maxScoopsForCone = 3;

    private void Start()
    {
        AddIcecreamFlavor(ICECREAM.ANTIFREEZE_BLUE);
        AddIcecreamFlavor(ICECREAM.VELOCITY_VANILLA);
        AddIcecreamFlavor(ICECREAM.VELOCITY_VANILLA);
        AddToppingFlavor(TOPPING.TOPPING3);
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
        GameObject gameManagerObject = GameObject.Find("GameManager");
        GameManager gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        OrderCreation orderCreationScript = gameManagerObject.GetComponent<OrderCreation>();

        int orderNumber = orderCreationScript.orderNumber;
        int toppingNumber = orderCreationScript.toppingNumber;

        // Return true if this cone's Tracking number + topping Tracking number match the order.
        bool isMatch = coneTrackingNumber == orderNumber && toppingTrackingNumber == toppingNumber;
        gameManagerScript.orderIsMatched = isMatch;

        // Toggle GameManager.cs orderCompleted bool to be true so a new order can be made.
        gameManagerScript.orderCompleted = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !coneServed)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("Snowman"))
            {
                CompareAgainstOrder();
                // Disable cone
                transform.SetParent(other.transform, true);
                transform.position = other.transform.position + new Vector3(0f, 1f, 0f);
                transform.rotation = new Quaternion(0f,0f,0f,0f);
                Destroy(GetComponent<XRGrabInteractable>());
                Destroy(GetComponent<Rigidbody>());
                Destroy(GetComponent<BoxCollider>());

                //Set up snowman
                Snowman snowmanScript = other.GetComponent<Snowman>();
                snowmanScript.targetPos = snowmanScript.snowmanPosition2.position;
                snowmanScript.cone = this.gameObject;

                coneServed = true;
            }
        }
    }
}
