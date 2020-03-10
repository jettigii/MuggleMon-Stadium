using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monPrevItem : MonoBehaviour
{

    public int mon_num;

    public GameObject StadiumMonsterController;
    private MonsterGameObjects MGO;
    private Mugglemon_Database MDB;
    private moves_Database movesDB;

    private GameObject mon_obj;
    public GameObject mon_placeHolder;
    public Text txtName;
    public Text txtNum;
    public Text txtHP;
    public Text txtWeight;
    public Text txtTyping;
    public Text txtHeight;
    public Text txtMove1;
    public Text txtMove2;
    public Text txtMove3;
    public Text txtMove4;
    public Text txtStats;
    public Text txtDesc;


    // Start is called before the first frame update
    void Start()
    {
        MGO = StadiumMonsterController.GetComponent(typeof(MonsterGameObjects)) as MonsterGameObjects;
        MDB = new Mugglemon_Database();
        movesDB = new moves_Database();
        //mon_obj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMon()
    {
        print(mon_num);
        //load model
        foreach (Transform child in mon_placeHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //mon_placeHolder = new GameObject();
        //mon_obj = new GameObject();
        mon_obj = Instantiate(MGO.mons[mon_num], new Vector3(0, 0, 0), Quaternion.identity);
        mon_obj.transform.parent = mon_placeHolder.transform;
        mon_obj.transform.localPosition = new Vector3(0, 0, 0);
        mon_obj.transform.Rotate(0, 180, 0);
        //mon_obj.transform.localScale = MDB.MuggleDex[mon_num].displayScale * 100;
        mon_obj.transform.localScale = mon_obj.transform.localScale * 100;

        //mon_placeHolder = "";
        //load stats
        txtName.text = MDB.MuggleDex[mon_num].mon_name;
        txtNum.text = mon_num.ToString();
        txtHP.text = MDB.MuggleDex[mon_num].maxHP.ToString();
        txtHP.text = txtHP.text + " / " + txtHP.text;
        txtWeight.text = MDB.MuggleDex[mon_num].maxWeight.ToString();
        txtTyping.text = MDB.MuggleDex[mon_num].type + " /\n" + MDB.MuggleDex[mon_num].type2;
        txtHeight.text = MDB.MuggleDex[mon_num].maxWeight.ToString();
        //moves
        txtMove1.text = movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[0]].move_name;
        txtMove1.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[0]].type).type_color;
        txtMove2.text = movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[1]].move_name;
        txtMove2.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[1]].type).type_color;
        if (MDB.MuggleDex[mon_num].possibleMoves.Length > 2)
        {
            txtMove3.text = movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[2]].move_name;
            txtMove3.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[2]].type).type_color;
            txtMove4.text = movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[3]].move_name;
            txtMove4.GetComponent<Text>().color = movesDB.getTypingData(movesDB.MoveList[MDB.MuggleDex[mon_num].possibleMoves[2]].type).type_color;
        }
        //stats
        txtStats.text = "Attack: " + MDB.MuggleDex[mon_num].maxATK.ToString() + "\nDefense: " + MDB.MuggleDex[mon_num].maxDEF.ToString() + "\nSpeed: " + MDB.MuggleDex[mon_num].maxSPD.ToString();
        //Description
        txtDesc.text = MDB.MuggleDex[mon_num].mon_desc.ToString();
    }

    
    

}
