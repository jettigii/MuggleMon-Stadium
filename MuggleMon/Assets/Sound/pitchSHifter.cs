using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitchSHifter : MonoBehaviour
{

    public AudioSource ass;
    public float pitchVolume;

    // Start is called before the first frame update
    void Start()
    {
        ass.pitch = pitchVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
