using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StadiumCanvasComponent : MonoBehaviour
{
    /// <summary>
    /// Player1
    /// </summary>
    public Text p1Name;
    public Text p1MonName;
    public Text p1Status; //format: L50\t\tOK
    public Image p1HealthBar;// change fill amount: 0.0 to 1.0
    public Text p1Health;//format: 150/150
    public Image p1MonPic;
    public Image p1IcoMon1, p1IcoMon2, p1IcoMon3, p1IcoMon4, p1IcoMon5, p1IcoMon6; //change visibilty based on faint or not
    public Text p1Move1, p1Move2, p1Move3, p1Move4;
    public Text p1Mon1, p1Mon2, p1Mon3, p1Mon4, p1Mon5, p1Mon6; //names of mons player has
    public Button p1pnlBattle;
    public Button p1pnlMons;
    public GameObject p1pnlReady;

    public GameObject SPACER;
    /// <summary>
    /// Player2
    /// </summary>
    public Text p2Name;
    public Text p2MonName;
    public Text p2Status; //format: L50\t\tOK
    public Image p2HealthBar;// change fill amount: 0.0 to 1.0
    public Text p2Health;//format: 150/150
    public Image p2MonPic;
    public Image p2IcoMon1, p2IcoMon2, p2IcoMon3, p2IcoMon4, p2IcoMon5, p2IcoMon6; //change visibilty based on faint or not
    public Text p2Move1, p2Move2, p2Move3, p2Move4;
    public Text p2Mon1, p2Mon2, p2Mon3, p2Mon4, p2Mon5, p2Mon6; //names of mons player has
    public Button p2pnlBattle;
    public Button p2pnlMons;
    public GameObject p2pnlReady;


    private Mugglemon_Database mmDB = new Mugglemon_Database();
    public GameObject StadiumMonsterController;
    private MonsterGameObjects MGO;
    private moves_Database movesDB;

    private void Start()
    {
        mmDB = new Mugglemon_Database();
        movesDB = new moves_Database();
        MGO = StadiumMonsterController.GetComponent(typeof(MonsterGameObjects)) as MonsterGameObjects;
        
    }
    
    public void forceChangeMonsPlayer1()
    {

    }

    public void showMonStats(Mugglemon_Data mon, int[] monList, int player)
    {
        p1pnlBattle.enabled = true;
        p2pnlBattle.enabled = true;

        if (player == 0)
        {
            //Display mon stats
            p1Name.text = "Player 1";
            p1MonName.text = mmDB.MuggleDex[mon.mon_num-1].mon_name;
            p1Status.text = "L50\t\tOK";
            float curHealth = mon.mon_health;
            float maxHP = mmDB.MuggleDex[mon.mon_num - 1].maxHP;
            p1HealthBar.fillAmount = curHealth / maxHP;
            p1Health.text = mon.mon_health.ToString() + " / " + mmDB.MuggleDex[mon.mon_num-1].maxHP.ToString();
            p1MonPic.sprite = getMonSprite(mmDB.MuggleDex[mon.mon_num - 1].mon_num);//mmDB.MuggleDex[mon.mon_num-1].sprite;

            //Display mon moves
            p1Move1.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].move_name;
            p1Move1.color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].type).type_color;
            p1Move2.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[1]].move_name;
            p1Move2.color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[1]].type).type_color;
            try
            {
                p1Move3.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[2]].move_name;
                p1Move3.color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[2]].type).type_color;
                p1Move4.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[3]].move_name;
                p1Move4.color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[3]].type).type_color;
            } catch
            {
                p1Move3.text = "-";
                p1Move4.text = "-";
            }

            //Display mon names
            if (monList[0] != -1) { p1Mon1.color = Color.black; p1Mon1.text = mmDB.MuggleDex[monList[0]].mon_name; }
            else { p1Mon1.color = Color.red; p1Mon1.text = "[ FAINTED ]"; }
            if (monList[1] != -1) { p1Mon2.color = Color.black; p1Mon2.text = mmDB.MuggleDex[monList[1]].mon_name; }
            else { p1Mon2.color = Color.red; p1Mon2.text = "[ FAINTED ]"; }
            if (monList[2] != -1) { p1Mon3.color = Color.black; p1Mon3.text = mmDB.MuggleDex[monList[2]].mon_name; }
            else { p1Mon3.color = Color.red; p1Mon3.text = "[ FAINTED ]"; }
            if (monList[3] != -1) { p1Mon4.color = Color.black; p1Mon4.text = mmDB.MuggleDex[monList[3]].mon_name; }
            else { p1Mon4.color = Color.red; p1Mon4.text = "[ FAINTED ]"; }
            if (monList[4] != -1) { p1Mon5.color = Color.black; p1Mon5.text = mmDB.MuggleDex[monList[4]].mon_name; }
            else { p1Mon5.color = Color.red; p1Mon5.text = "[ FAINTED ]"; }
            if (monList[5] != -1) { p1Mon6.color = Color.black; p1Mon6.text = mmDB.MuggleDex[monList[5]].mon_name; }
            else { p1Mon6.color = Color.red; p1Mon6.text = "[ FAINTED ]"; }

            //p1Mon2.text = mmDB.MuggleDex[monList[1]].mon_name;
            //p1Mon3.text = mmDB.MuggleDex[monList[2]].mon_name;
            //p1Mon4.text = mmDB.MuggleDex[monList[3]].mon_name;
            //p1Mon5.text = mmDB.MuggleDex[monList[4]].mon_name;
            //p1Mon6.text = mmDB.MuggleDex[monList[5]].mon_name;
            
            int count = 0;
            foreach (int i in monList)
            {
                if (i != -1)
                {
                    count++;
                }
            }

            p1IcoMon1.gameObject.active = (count > 0);
            p1IcoMon2.gameObject.active = (count > 1);
            p1IcoMon3.gameObject.active = (count > 2);
            p1IcoMon4.gameObject.active = (count > 3);
            p1IcoMon5.gameObject.active = (count > 4);
            p1IcoMon6.gameObject.active = (count > 5);

        }
        // Player 2
        else
        {
            p2Name.text = "Player 2";
            p2MonName.text = mmDB.MuggleDex[mon.mon_num - 1].mon_name;
            p2Status.text = "L50\t\tOK";
            float curHealth = mon.mon_health;
            float maxHP = mmDB.MuggleDex[mon.mon_num - 1].maxHP;
            p2HealthBar.fillAmount = curHealth / maxHP;
            p2Health.text = mon.mon_health.ToString() + " / " + mmDB.MuggleDex[mon.mon_num-1].maxHP.ToString();
            p2MonPic.sprite = getMonSprite(mmDB.MuggleDex[mon.mon_num - 1].mon_num);//mmDB.MuggleDex[mon.mon_num-1].sprite;

            p2Move1.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].move_name;
            p2Move1.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].type).type_color;
            p2Move2.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[1]].move_name;
            p2Move2.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[1]].type).type_color;
            try
            {
                p2Move3.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[2]].move_name;
                p2Move3.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[2]].type).type_color;
                p2Move4.text = movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[3]].move_name;
                p2Move4.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[3]].type).type_color;
            }
            catch
            {
                p2Move3.text = "-";
                p2Move4.text = "-";
            }

            //Display mon names
            if (monList[0] != -1) { p2Mon1.color = Color.black; p2Mon1.text = mmDB.MuggleDex[monList[0]].mon_name; }
            else { p2Mon1.color = Color.red; p2Mon1.text = "[ FAINTED ]"; }
            if (monList[1] != -1) { p2Mon2.color = Color.black; p2Mon2.text = mmDB.MuggleDex[monList[1]].mon_name; }
            else { p2Mon2.color = Color.red; p2Mon2.text = "[ FAINTED ]"; }
            if (monList[2] != -1) { p2Mon3.color = Color.black; p2Mon3.text = mmDB.MuggleDex[monList[2]].mon_name; }
            else { p2Mon3.color = Color.red; p2Mon3.text = "[ FAINTED ]"; }
            if (monList[3] != -1) { p2Mon4.color = Color.black; p2Mon4.text = mmDB.MuggleDex[monList[3]].mon_name; }
            else { p2Mon4.color = Color.red; p2Mon4.text = "[ FAINTED ]"; }
            if (monList[4] != -1) { p2Mon5.color = Color.black; p2Mon5.text = mmDB.MuggleDex[monList[4]].mon_name; }
            else { p2Mon5.color = Color.red; p2Mon5.text = "[ FAINTED ]"; }
            if (monList[5] != -1) { p2Mon6.color = Color.black; p2Mon6.text = mmDB.MuggleDex[monList[5]].mon_name; }
            else { p2Mon6.color = Color.red; p2Mon6.text = "[ FAINTED ]"; }

            //p2Mon1.text = mmDB.MuggleDex[monList[0]].mon_name;
            //p2Mon2.text = mmDB.MuggleDex[monList[1]].mon_name;
            //p2Mon3.text = mmDB.MuggleDex[monList[2]].mon_name;
            //p2Mon4.text = mmDB.MuggleDex[monList[3]].mon_name;
            //p2Mon5.text = mmDB.MuggleDex[monList[4]].mon_name;
            //p2Mon6.text = mmDB.MuggleDex[monList[5]].mon_name;

            int count = 0;
            foreach (int i in monList)
            {
                if (i != -1)
                {
                    count++;
                }
            }

            p2IcoMon1.gameObject.active = (count > 0);
            p2IcoMon2.gameObject.active = (count > 1);
            p2IcoMon3.gameObject.active = (count > 2);
            p2IcoMon4.gameObject.active = (count > 3);
            p2IcoMon5.gameObject.active = (count > 4);
            p2IcoMon6.gameObject.active = (count > 5);
        }
    }

    private Sprite getMonSprite(int num)
    {
        Sprite sprite;
        string strNum;


        if (num != -1)
        {
            Mugglemon_Data mmD = MGO.mons[num-1].GetComponent(typeof(Mugglemon_Data)) as Mugglemon_Data;
            sprite = mmD.sprite;
        }
        else
            sprite = null;

        return sprite;
    }
}
