using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpScale : MonoBehaviour
{
    public GameObject Pposition;

    public GameObject sparkle;

    public AudioSource MonOut;
    public AudioSource MonIn;

    public GameObject muggleMid;

    private Vector3 fromScale;
    private Vector3 toScale;
    //public float speed = 1F;

    private bool begin = false;
    bool repeatable;
    private float speed = 0.5f;
    float duration = 2;
    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fromScale = new Vector3(0, 0, 0);
        toScale = new Vector3(1, 1, 1);

        //transform.localScale = fromScale;

        //rate = (1.0f / 2) * speed;
    }


    //Update is called once per frame
    void Update()
    {
        if (begin)//if (begin)
        {
            sparkle.transform.localPosition = Vector3.Lerp(fromScale, toScale, t);//Time.deltaTime * speed
            float x = Mathf.Lerp(fromScale.x, toScale.x, t);
            t += 0.5f * Time.deltaTime;
            if (t > 1.0f)
            {
                begin = false;
                
            }
            
        }
    }

    public void fly()
    {
        t = 0.0f;
        fromScale = new Vector3(0, 0, 0);
        toScale = new Vector3(0, 6, 0);
        begin = true;
        MonIn.gameObject.active = true;
    }
    public void fly2()
    {
        t = 0.0f;
        fromScale = new Vector3(0, 4, 0);
        toScale = new Vector3(0, 0, 0);
        begin = true;
        MonOut.gameObject.active = true;
    }
    public void resetPOS()
    {
        MonOut.gameObject.active = false;
        MonIn.gameObject.active = false;
        begin = false;
        sparkle.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void shrinkPlay()
    {
        //Pposition.transform.localScale = new Vector3(1, 1, 1);
        //fromScale = new Vector3(1, 1, 1);
        //toScale = new Vector3(0, 0, 0);
        //begin = true;
        //yield return RepeatLerp(fromScale, toScale, duration);

        //yield return ScaleDownAnimation(3.0f);

        //sparkle.active = false;
    }
    public void growPlay()
    {
        //Pposition.transform.localScale = new Vector3(1, 1, 1);
        //fromScale = new Vector3(0, 0, 0);
        //toScale = new Vector3(1, 1, 1);
        //begin = true;
        //yield return RepeatLerp(fromScale, toScale, duration);

        //yield return ScaleDownAnimation(3.0f);

        //sparkle.active = true;
    }
    
    
    
    //public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    //{
    //    float i = 0.0f;
    //    float rate = (1.0f / time) * speed;
    //    while (i < 1.0f)
    //    {
    //        i += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(a, b, i);
    //        yield return null;
    //    }
    //}

    //IEnumerator ScaleDownAnimation(float time)
    //{
    //    float i = 0;
    //    float rate = 1 / time;

    //    Vector3 fromScale = transform.localScale;
    //    Vector3 toScale = Vector3.zero;
    //    while (i < 1)
    //    {
    //        i += Time.deltaTime * rate;
    //        Pposition.transform.localScale = Vector3.Lerp(fromScale, toScale, i);
    //        yield return 0;
    //    }
    //}

}
