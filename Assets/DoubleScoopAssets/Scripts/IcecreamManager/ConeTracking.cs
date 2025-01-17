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
    [SerializeField] private int maxScoopsForCone = 2;
    public Transform scoop1Pos;
    public Transform scoop2Pos;
    public Transform scoop3Pos;

    private void Start()
    {
        AddToppingFlavor(TOPPING.TOPPING3);
    }

    public void AddIcecreamFlavor(ICECREAM flavor) // Call this when adding a Scoop of icecream to the cone.
    {
        if (currentScoops < maxScoopsForCone)
        { // Do not allow the player to add more scoops if maxscoops have already been added.
            AudioManager.instance.PlaySound("Pop");
            float rate = 10f;
            coneTrackingNumber += (int)flavor * (int)Mathf.Pow(rate, currentScoops);
            currentScoops++;
        }
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
        bool isMatch = coneTrackingNumber == orderNumber;
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

                // Set up snowman
                Snowman snowmanScript = other.GetComponent<Snowman>();
                snowmanScript.cone = this.gameObject;
                snowmanScript.SetNewDestination(snowmanScript.snowmanPosition2.position);
                AudioManager.instance.PlaySound("SnowmanMove");

                coneServed = true;
            }
            if (other.CompareTag("Scoop"))
            {
                if (currentScoops <= 2)
                {
                    // Reparent to the cone
                    other.transform.SetParent(transform, true);
                    switch (currentScoops)
                    {
                        case 0:
                            other.transform.position = scoop1Pos.position;
                            other.transform.rotation = scoop1Pos.rotation;
                            break;
                        case 1:
                            other.transform.position = scoop2Pos.position;
                            break;
                        case 2:
                            other.transform.position = scoop3Pos.position;
                            break;
                    }

                    // Disable collisions on the scoop
                    Destroy(other.GetComponent<Rigidbody>());
                    Destroy(other.GetComponent<BoxCollider>());
                    // Get the ice cream flavor from the scoop script and add
                    IceCreamScoop scoopScript = other.GetComponent<IceCreamScoop>();
                    IceCreamScooper scooper = scoopScript.scooper;
                    ICECREAM scoop = scoopScript.flavour;
                    scooper.hasScoop = false;
                    AddIcecreamFlavor(scoop);
                }
            }
        }
    }
}
