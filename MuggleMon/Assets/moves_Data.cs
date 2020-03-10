using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moves_Data : MonoBehaviour
{
    public int move_num;
    public string move_name;
    public string type;
    public int power;
    public int speed;
    public int user_atk_growth;
    public int user_def_growth;
    public int opp_atk_growth;
    public int opp_def_growth;
    public string desc;

    public string effect_visual;
    public string effect_sound;
    public float time_duration;//how many seconds does the move animation need to complete?
    public GameObject effect;
    public bool boolSpecial = false;

    public moves_Data() { }
}
