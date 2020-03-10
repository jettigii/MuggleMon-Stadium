using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomSound : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        int index = Random.Range(0, shoot.Length);
        shootClip = shoot[index];
        audioSource.clip = shootClip;
        audioSource.Play();
    }
    
}
