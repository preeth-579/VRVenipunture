using UnityEngine;
using BNG;

public class HandsGloveColorChange : MonoBehaviour
{
    [Header("Assign Both Gloves Here")]
    public SkinnedMeshRenderer leftGlove;
    public SkinnedMeshRenderer rightGlove;

    [Header("White Material")]
    public Material whiteMaterial;

    private Material[] leftOriginalMats;
    private Material[] rightOriginalMats;
    
    [Header("Grabbable Cotton")]
    public Grabbable CottonGrabbable;
    
    [Header("SnapZone Cotton")]
    public SnapZone CottonSnapZone;
    

    private void Start()
    {
        // Store original materials at start
        leftOriginalMats = leftGlove.materials;
        rightOriginalMats = rightGlove.materials;

        if (CottonGrabbable != null)
        {
            CottonGrabbable.enabled = false;
        }

        if (CottonSnapZone != null)
        {
            CottonSnapZone.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            if (SimulationManager.instance.hasWashedHands)
            {
                if (!SimulationManager.instance.hasWornGloves)
                {
                    ChangeToWhite(other);
                
                    SimulationManager.instance.hasWornGloves =  true;

                    if (CottonGrabbable != null)
                    {
                        CottonGrabbable.enabled = true;
                    }

                    if (CottonSnapZone != null)
                    {
                        CottonSnapZone.enabled = true;
                    }
                    
                    Debug.Log("Worn Gloves");
                }
            }
            else
            {
                {
                    Debug.Log("Wash your hands first");
                }
            }
        }
    }

    void ChangeToWhite(Collider handCollider)
    {
        if (leftGlove != null)
        {
            Material[] leftMats = leftGlove.materials;
            for (int i = 0; i < leftMats.Length; i++)
                leftMats[i] = whiteMaterial;
            leftGlove.materials = leftMats;
        }

        if (rightGlove != null)
        {
            Material[] rightMats = rightGlove.materials;
            for (int i = 0; i < rightMats.Length; i++)
                rightMats[i] = whiteMaterial;
            rightGlove.materials = rightMats;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ResetColors();
        }
    }

    void ResetColors()
    {
        if (leftGlove != null)
        {
            leftGlove.materials = leftOriginalMats;
        }

        if (rightGlove != null)
        {
            rightGlove.materials = rightOriginalMats;
        }
        
        SimulationManager.instance.hasWornGloves = false;

        if (CottonGrabbable != null)
        {
            CottonGrabbable.enabled = false;
        }

        if (CottonSnapZone != null)
        {
            CottonSnapZone.enabled = false;
        }
    }
}