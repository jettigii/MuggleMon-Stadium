using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{

    public float scrollSpeedH = 0.5F;
    public float scrollSpeedV = 0.5F;
    public Renderer rend;

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

        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetH, offsetV));
    }
}
