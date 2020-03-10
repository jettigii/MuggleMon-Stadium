using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomGimbalScript : MonoBehaviour
{

    public Transform from;
    public Transform to;

    public Vector3 fromPos;
    public Vector3 fromRot;

    //public Vector3 fromPos;
    //public Vector3 fromRot;

    //public Vector3 toPos;
    //public Vector3 toRot;

    public float speed = 2f;
    private bool begin = false;

    // Start is called before the first frame update
    void Start()
    {
        //from = 
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(from.position, to.position, Time.deltaTime * speed);
        }
    }

    public void Play()
    {
        begin = true;
    }

    public void restart()
    {
        begin = false;
        //transform.position = from.position;
        //transform.rotation = from.rotation;

        //transform.position = fromPos;
        transform.localPosition = fromPos;
        transform.rotation = Quaternion.Euler(fromRot);
    }

}
