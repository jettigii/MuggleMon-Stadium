using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuggleClass : MonoBehaviour
{
    public int mon_number;
    public string nickname;
    public int gender;
    public int weight;
    public int shiny;
    public int level;
    public int exp;
    public int currentHP;
    public int hp;
    public int atk;
    public int def;
    public int speed;
    public int move1;
    public int move2;
    public int move3;
    public int move4;
    
    public string getString()
    {
        string txt = mon_number + "," + nickname + "," + gender + "," + weight + "," + shiny + "," + level + "," + exp + "," + currentHP + "," + hp + "," + atk + "," + def + "," + speed + "," + move1 + "," + move2 + "," + move3 + "," + move4;
        return txt;
    }

    public MuggleClass(string txt)
    {
        string[] statList = txt.Split(',');

        mon_number = int.Parse(statList[0]);
        nickname = statList[1];
        gender = int.Parse(statList[2]);
        weight = int.Parse(statList[3]);
        shiny = int.Parse(statList[4]);
        level = int.Parse(statList[5]); 
        exp = int.Parse(statList[6]); 
        currentHP = int.Parse(statList[7]); 
        hp = int.Parse(statList[8]); 
        atk = int.Parse(statList[9]); 
        def = int.Parse(statList[10]); 
        speed = int.Parse(statList[11]); 
        move1 = int.Parse(statList[12]); 
        move2 = int.Parse(statList[13]); 
        move3 = int.Parse(statList[14]);
        move4 = int.Parse(statList[15]);
    }

    public MuggleClass() { }
}
