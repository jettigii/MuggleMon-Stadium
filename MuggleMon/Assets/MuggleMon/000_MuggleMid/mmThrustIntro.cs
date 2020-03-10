using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmThrustIntro : MonoBehaviour
{

    public float thrust;
    public float thrustForward;
    public Rigidbody rb;

    public GameObject stadiumGameCOntroller;
    private StadiumGame sg;

    public GameObject mid2;

    public int mid;

    // Start is called before the first frame update
    void Start()
    {
        sg = stadiumGameCOntroller.GetComponent(typeof(StadiumGame)) as StadiumGame;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrustForward);
        rb.AddForce(transform.up * thrust);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (mid == 0)
        {
            mid2.active = true;
        } else
        {
            sg.introDone = true;
        }
    }
    
}
