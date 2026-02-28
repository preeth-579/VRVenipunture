using UnityEngine;

public class HandsGloveColorChange : MonoBehaviour
{
    [Header("White Material")]
    public Material whiteMaterial;

    private void OnTriggerEnter(Collider other)
    {
        // LEFT HAND
        if (other.CompareTag("Hands"))
        {
            ChangeHandColor(other);
        }
    }

    void ChangeHandColor(Collider handCollider)
    {
        SkinnedMeshRenderer rend = handCollider.GetComponentInChildren<SkinnedMeshRenderer>();

        if (rend != null)
        {
            Material[] mats = rend.materials;

            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = whiteMaterial;
            }
            rend.materials = mats;
        }
    }
}