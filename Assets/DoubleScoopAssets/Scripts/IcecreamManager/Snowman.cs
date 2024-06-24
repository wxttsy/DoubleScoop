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
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPos);

        // Move snowman away from kiosk
        if (targetPos == snowmanPosition2.position && agent.remainingDistance <= agent.stoppingDistance)
        {
            LineUp();
        }
        // Move snowman to kiosk
        if (targetPos == snowmanPosition1.position && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Look at player
            Quaternion targetRotation = new Quaternion(0f, 180f, 0f,0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void LineUp()
    {
        //Remove cone attached as child.
        Destroy(cone);
        //Move snowman to new target position.
        transform.position = snowmanReset.position;
        targetPos = snowmanPosition1.position;
    }
}
