using UnityEngine;

public class HandsGloveColorChange : MonoBehaviour
{
    [Header("Assign Both Gloves Here")]
    public SkinnedMeshRenderer leftGlove;
    public SkinnedMeshRenderer rightGlove;

    [Header("White Material")]
    public Material whiteMaterial;

    private Material[] leftOriginalMats;
    private Material[] rightOriginalMats;

    private void Start()
    {
        // Store original materials at start
        leftOriginalMats = leftGlove.materials;
        rightOriginalMats = rightGlove.materials;
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
                    SimulationManager.instance.UnLockGrabbableObjects();
                
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
        SimulationManager.instance.LockGrabbableObjects();
    }
}