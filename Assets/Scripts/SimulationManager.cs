using System;
using BNG;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    //Singleton 
    public static SimulationManager instance;
    
    [Header("Game Objects")]
    public GameObject XRRigPlayerController;
    public GameObject HomeCanvas;
    public GameObject SimulationObjects;
    
    [Header("Grabbable Objects")] 
    public GameObject[] grabbableObjects;

    [Header("Conditions")] 
    public bool hasWashedHands = false;
    public bool hasWornGloves = false;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance =  this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        HomeCanvas.SetActive(true);
        XRRigPlayerController.GetComponent<SmoothLocomotion>().UpdateMovement = false;
        SimulationObjects.SetActive(false);
        
        LockGrabbableObjects();
    }

    public void StartSimulation()
    {
        HomeCanvas.SetActive(false);
        XRRigPlayerController.GetComponent<SmoothLocomotion>().UpdateMovement = true;
        SimulationObjects.SetActive(true);
    }

    public void UnLockGrabbableObjects()
    {
        foreach (GameObject grabobj in grabbableObjects)
        {
            if (grabobj != null)
            {
                Grabbable grabbableComponent = grabobj.GetComponent<Grabbable>();

                if (grabbableComponent != null)
                {
                    grabbableComponent.enabled = true;
                }
            }
        }
        Debug.Log("UnLockGrabbableObjects");
    }

    public void LockGrabbableObjects()
    {
        foreach (GameObject grabobj in grabbableObjects)
        {
            if (grabobj != null)
            {
                Grabbable grabbableComponent = grabobj.GetComponent<Grabbable>();

                if (grabbableComponent != null)
                {
                    grabbableComponent.enabled = false;
                }
            }
        }
        Debug.Log("LockGrabbableObjects");
    }
}
