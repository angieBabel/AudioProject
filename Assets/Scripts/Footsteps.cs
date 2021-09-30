using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] foosterStepClips;
    public AudioSource audioSource;

    public CharacterController controller;

    public float footStepThreshold;
    public float footStepRate;
    private float lastFootSteepTime;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.velocity.magnitude > footStepThreshold)
        {
            if(Time.time - lastFootSteepTime> footStepRate)
            {
                lastFootSteepTime = Time.time;
                audioSource.PlayOneShot(foosterStepClips[Random.Range(0,foosterStepClips.Length)]);
            }
        }
    }
}
