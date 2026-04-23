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
    }

    public void StartSimulation()
    {
        HomeCanvas.SetActive(false);
        XRRigPlayerController.GetComponent<SmoothLocomotion>().UpdateMovement = true;
        SimulationObjects.SetActive(true);
    }
}
