using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    [Header ("Water Particle System")]
    public ParticleSystem waterParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hands"))
        {
            if (!waterParticleSystem.isPlaying)
            {
                waterParticleSystem.Play();
            }
            
            SimulationManager.instance.hasWashedHands = true;
            
            Debug.Log("Washed Hands");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hands"))
        {
            waterParticleSystem.Stop();
        }
    }
}