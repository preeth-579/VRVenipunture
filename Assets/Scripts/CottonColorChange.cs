using System;
using UnityEngine;

public class CottonColorChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cotton"))
        {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
