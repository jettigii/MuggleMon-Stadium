using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugglemon_Data : MonoBehaviour
{
    public int mon_num;
    public string mon_name;
    public string mon_desc;
    public string type;
    public string type2;
    public float genderMaleChance;
    public int minWeight;
    public int maxWeight;
    public Color shiny;
    public int nextLevelexp;
    public int minHP;
    public int maxHP;
    public int minATK;
    public int maxATK;
    public int minDEF;
    public int maxDEF;
    public int minSPD;
    public int maxSPD;
    public int[] possibleMoves;
    public bool canEvolve;
    public int evolutionMonNum;
    public int evolutionLevel;
    public Sprite sprite;

    public int currentATK_MOD;
    public int currentDEF_MOD;

    public Vector3 displayScale;
    public Vector3 displayPosition;
    public GameObject mon_gameObject;
    public Animator mon_animatorController;

    public int mon_health;
    public bool currentlyOut;
    public string status;

    public Mugglemon_Data() { }
}
