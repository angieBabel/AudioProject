using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{

    public AudioSource audioSource;
    public float fadeTime;
    private float targetVolumen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolumen = 1.0f;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolumen = 0.0f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetVolumen = 0.0f;
        audioSource.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolumen,(1.0f/fadeTime) * Time.deltaTime);
    }
}
