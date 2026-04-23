using System;
using UnityEngine;
using BNG;

public class CottonColorChange : MonoBehaviour
{
    [Header("Grabbable Band")] 
    public Grabbable handBand;

    private void Start()
    {
        if (handBand != null)
        {
            handBand.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cotton"))
        {
            other.GetComponent<Renderer>().material.color = Color.red;

            if (handBand != null)
            {
                handBand.enabled = true;
            }
        }
    }
}
