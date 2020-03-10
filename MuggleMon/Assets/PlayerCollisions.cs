using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public Collision colliderA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.name != "Earth")
        {
            //if (collision.collider.GetType() == typeof(BoxCollider))
            //    tag = "Player";
            //else if (collision.collider.GetType() == typeof(SphereCollider))
            //    tag = "CenterToBuilding";

            //print("New tag name: " + tag);
            //colliderA = collision;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //if (collision.collider.GetType() == typeof(SphereCollider))
        //    tag = "CenterToBuilding";
        colliderA = collision;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name != "Earth")
        {
            //tag = "Untagged";
            //print("New tag name: " + tag);

            colliderA = collision;
        }
    }
}
