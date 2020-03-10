using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollObject : MonoBehaviour
{

    public float scrollSpeedH = 0.5F;
    public float scrollSpeedV = 0.5F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float offsetH = transform.rotation.x + scrollSpeedH;
        //float offsetV = transform.rotation.y + scrollSpeedV;

        //transform.Rotate(offsetH, offsetV, 0);
        transform.Rotate((scrollSpeedH * Time.deltaTime), 0 , (scrollSpeedV * Time.deltaTime));
    }
}
