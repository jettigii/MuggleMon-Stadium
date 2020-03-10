using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTexture : MonoBehaviour
{
    public float scrollSpeedH = 0.5F;
    public float scrollSpeedV = 0.5F;
    public float scrollSpeed = 1F;
    private float nextActionTime = 0.0f;
    public Renderer rend;
    private bool texOff = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetH = Time.time * scrollSpeedH;
        float offsetV = Time.time * scrollSpeedV;

        if (Time.time > nextActionTime)
        {
            if (texOff)
                rend.material.SetTextureOffset("_MainTex", new Vector2(scrollSpeedH, scrollSpeedV));
            else
                rend.material.SetTextureOffset("_MainTex", new Vector2(0, 0));

            texOff = !texOff;
            nextActionTime += scrollSpeed;
            // execute block of code here
            
        }

        
    }
}
