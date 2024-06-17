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
    FLAVOR7, // NOTE: TBA undecided flavor
    ORANGE_PAINT,
    DEPLETED_URANIUM
}



public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
