using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StadiumPlayerControls : MonoBehaviour
{

    public int player;
    public int attack_num;
    public int mon_num;
    public GameObject StadiumController;
    private StadiumGame sg;
    public GameObject readyPanel;

    public StadiumPlayerControls()
    {
        //sg = StadiumController.GetComponent(typeof(StadiumGame)) as StadiumGame;
    }

    void Start()
    {
        sg = StadiumController.GetComponent(typeof(StadiumGame)) as StadiumGame;
    }

    public void willAttack()
    {
        //send attack_num
        if (player == 0)
        {
            sg.p1Action = 0;
            sg.p1move_num = attack_num;
            sg.p1Ready = true;
            readyPanel.active = true;
        } else
        {
            sg.p2Action = 0;
            sg.p2move_num = attack_num;
            sg.p2Ready = true;
            readyPanel.active = true;
        }
    }

    public void willChangeMon()
    {
        //send mon_num
        if (player == 0)
        {
            if (sg.monList[mon_num] != -1)
            {
                //send
                sg.p1Action = 1;
                sg.p1mon_num = mon_num;
                sg.p1Ready = true;
                readyPanel.active = true;
            }
        } else
        {
            if (sg.monList2[mon_num] != -1)
            {
                //send
                sg.p2Action = 1;
                sg.p2mon_num = mon_num;
                sg.p2Ready = true;
                readyPanel.active = true;
            }
        }
    }

    public void willFlee()
    {
        //send serender command
        if (player == 0)
        {
            print("Player1 quits");
            sg.p1Action = 2;
            sg.p1Ready = true;
        }
        else
        {
            print("Player2 quits");
            sg.p2Action = 2;
            sg.p2Ready = true;
        }

        readyPanel.active = true;
    }

}
