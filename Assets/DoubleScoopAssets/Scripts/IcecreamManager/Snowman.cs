using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Snowman : MonoBehaviour
{
    public float turnSpeed = 0.05f;
    [HideInInspector] public GameObject gameManagerObject;
    [HideInInspector] public GameManager gameManagerScript;
    
    [HideInInspector] public Transform snowmanPosition1;
    [HideInInspector] public Transform snowmanPosition2;
    [HideInInspector] public Transform snowmanReset;
    public GameObject sunglasses;
    public GameObject scarf;
    public GameObject hat;

    private NavMeshAgent agent;
    public Vector3 targetPos;

    [HideInInspector] public GameObject cone = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();

        snowmanPosition1 = gameManagerScript.snowmanPosition1;
        snowmanPosition2 = gameManagerScript.snowmanPosition2;
        snowmanReset = gameManagerScript.snowmanReset;
        agent = GetComponent<NavMeshAgent>();
        targetPos = snowmanPosition1.transform.position;
        SetNewDestination(snowmanPosition1.position);
        SetAccessories();
    }

    public void SetNewDestination(Vector3 pos)
    {
        agent.SetDestination(pos);
        targetPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        // Move snowman away from kiosk
        if (targetPos == snowmanPosition2.position && agent.remainingDistance <= agent.stoppingDistance)
        {
            AudioManager.instance.PlaySound("SnowmanMove");
            LineUp();
        }
        // Move snowman to kiosk
        if (targetPos == snowmanPosition1.position && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Look at player
            AudioManager.instance.PlaySound("OrderCall");
            Quaternion targetRotation = new Quaternion(0f, 180f, 0f,0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void LineUp() {
        //Remove cone attached as child.
        Destroy(cone);
        //Move snowman to new target position.
        transform.position = snowmanReset.position;
        SetNewDestination(snowmanPosition1.position);
        SetAccessories();
    }

    private void SetAccessories()
    {
        float showSunglasses = Random.Range(0, 2);
        float showHat = Random.Range(0, 2);
        float showScarf = Random.Range(0, 2);

        if (showSunglasses == 0) sunglasses.SetActive(false);
        else sunglasses.SetActive(true);

        if (showHat == 0) hat.SetActive(false);
        else hat.SetActive(true);

        if (showScarf == 0) scarf.SetActive(false);
        else scarf.SetActive(true);
    }
}
