using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject menuUI;
    [SerializeField]
    GameObject scooper;
    XRIDefaultInputActions input;
    private void Awake()
    {
        input = new XRIDefaultInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        input.Enable();
        //input.XRIRightHand.Scoop.performed += Scoop;
        input.XRILeftHand.Menu.performed += Menu;
    }

    private void Menu(InputAction.CallbackContext context)
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
            menuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menuUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Scoop(InputAction.CallbackContext context)
    //{
    //    if(scooper.GetComponentInChildren<IceCreamScooper>().canScoop)
    //    {
    //        scooper.GetComponentInChildren<IceCreamScooper>().ScoopIceCream();
    //    }
    //}
}
