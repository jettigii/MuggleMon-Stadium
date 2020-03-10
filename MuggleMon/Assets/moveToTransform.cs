using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToTransform : MonoBehaviour
{

    public Transform toTransform;
    public Transform fromTransform;
    public float speed = 1f;
    private bool begin = true;

    // Start is called before the first frame update
    void Start()
    {
        fromTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            transform.rotation = Quaternion.Lerp(fromTransform.rotation, toTransform.rotation, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(fromTransform.position, toTransform.position, Time.deltaTime * speed);
        }
    }
}
