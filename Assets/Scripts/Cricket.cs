using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricket : MonoBehaviour
{
    public AudioSource audioSource;
    public float stopDistance;

    private Transform player;
    private float defaultVolumen;

    // Start is called before the first frame update
    void Start()
    {
        defaultVolumen = audioSource.volume;
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            return;
        }

        float dist = Vector3.Distance(transform.position, player.position);

        if(dist > stopDistance)
        {
            audioSource.volume = defaultVolumen;
        }
        else
        {
            audioSource.volume = 0.0f;
        }
    }
}
