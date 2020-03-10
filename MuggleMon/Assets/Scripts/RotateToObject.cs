using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToObject : MonoBehaviour
{

    public GameObject rotator;
    public GameObject ObjecttoStare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotator.transform.LookAt(ObjecttoStare.transform);
    }
}
