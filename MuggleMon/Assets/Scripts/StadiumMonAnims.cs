using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumMonAnims : MonoBehaviour
{

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    private Animator anim1;
    private Animator anim2;

    public bool boolPlayer1Die = false;
    public bool boolPlayer2Die = false;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void player1Animation(string animation)
    {
        if (!boolPlayer1Die)
        {
            anim1 = player1Prefab.GetComponent<Animator>();
            anim1.Play(animation);
        }

        if (animation == "Die")
            boolPlayer1Die = true;
    }
    public void player2Animation(string animation)
    {
        if (!boolPlayer2Die)
        {
            anim2 = player2Prefab.GetComponent<Animator>();
            anim2.Play(animation);
        }

        if (animation == "Die")
            boolPlayer2Die = true;
    }
    
}
