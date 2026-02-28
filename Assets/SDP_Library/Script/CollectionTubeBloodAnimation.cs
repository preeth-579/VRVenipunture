using UnityEngine;

public class CollectionTubeBloodAnimation : MonoBehaviour
{ 
    private SkinnedMeshRenderer Blood;
    private int initialValue = 0;
    private float targetValue = 100;
    private float animationDuration = 5f;

    private float currentLerpValue = 0f;

    private int _index = 0;

    // Flag to control the animation state
    private bool lerper = false;
    public bool isTriggered = false;

    public void Start()
    {
        Blood = this.gameObject.GetComponent<SkinnedMeshRenderer>();



        if (Blood == null)
        {
            Debug.LogError("SkinnedMeshRenderer reference is not assigned!");
            return;
        }


    }
    public void Update()
    {
        if (lerper)
        {

            // Increment the interpolation value based on the elapsed time and animation duration
            currentLerpValue += Time.deltaTime;

            // Calculate the lerp value between the two blend shape weights
            float lerpValue = Mathf.Lerp(initialValue, targetValue, currentLerpValue / animationDuration);

            Debug.Log(lerpValue); 
            // Set the blend shape weights using the lerp value
            if (Blood)
            {
                if (_index >= 0)
                {
                    Blood.SetBlendShapeWeight(_index, lerpValue);
                    

                }


                

            }

            // Check if the animation is completed
            if (currentLerpValue >= animationDuration)
            {
                currentLerpValue = 0;
                lerper = false;
                isTriggered = true;
            }
        }
    }

    public void StartBloodFillAnimation()
    {
        // Reset the current lerp value
        currentLerpValue = 0f;

        
        // Start the lerp animation
        lerper = true;
        
    }
}
