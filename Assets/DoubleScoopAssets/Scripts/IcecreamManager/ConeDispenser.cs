using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ConeDispenser : MonoBehaviour
{
    [SerializeField] GameObject cone;
    [SerializeField] XRInteractionManager manager;
    [SerializeField] XRRayInteractor hand;
    [SerializeField] Transform instantiatePosition;

    [SerializeField] float cooldown = 0.0f;
    private float lastGrabTime = 0.0f;


    public void OnSelect()
    {
        if (cooldown + lastGrabTime < Time.time)
        {
            GameObject worldCone = Instantiate(cone, instantiatePosition.position, hand.transform.rotation);
            manager.SelectEnter(hand, worldCone.GetComponent<XRGrabInteractable>());
            lastGrabTime = Time.time;
        }
    }
}
