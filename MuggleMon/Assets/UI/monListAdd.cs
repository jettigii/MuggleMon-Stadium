using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monListAdd : MonoBehaviour
{
    public GameObject StadiumGameController;
    private StadiumGame sg;
    public GameObject StadiumMonsterController;
    private MonsterGameObjects MGO;
    private Mugglemon_Database MDB;

    public int player;
    public int[] monList = { -1, -1, -1, -1, -1, -1 };
    public Text txtnum;
    public Text btnAddRemoveText;

    public GameObject[] monPanels;

    public Image imgMon1;
    public Image imgMon2;
    public Image imgMon3;
    public Image imgMon4;
    public Image imgMon5;
    public Image imgMon6;

    // Start is called before the first frame update
    void Start()
    {
        MGO = StadiumMonsterController.GetComponent(typeof(MonsterGameObjects)) as MonsterGameObjects;
        MDB = new Mugglemon_Database();
        sg = StadiumGameController.GetComponent(typeof(StadiumGame)) as StadiumGame;
        //monList = new int[6];
    }

    // Update is called once per frame
    void Update()
    {
        if (monList[0] == int.Parse(txtnum.text) || monList[1] == int.Parse(txtnum.text) || monList[2] == int.Parse(txtnum.text) || monList[3] == int.Parse(txtnum.text) || monList[4] == int.Parse(txtnum.text) || monList[5] == int.Parse(txtnum.text))
        {
            //remove icon
            btnAddRemoveText.text = "-";
        }
        else
            btnAddRemoveText.text = "+";
    }

    public void addRemoveMon()
    {
        //print("start func");
        if (btnAddRemoveText.text == "+")
        {
            //add
            //print("adding");
            //clear mon items for preview
            //for (int i = 0; i >= 5; i++)
            //{
            //    foreach (Transform child in monPanels[i].transform)
            //    {
            //        GameObject.Destroy(child.gameObject);
            //    }
            //}

            int count = 0;
            foreach (int i in monList)
            {

                if (i == -1)
                {
                    monList[count] = int.Parse(txtnum.text);
                    break;
                }
                count++;
            }
            //print("adding: " + txtnum.text);

        } else
        {
            //remove
            //print("removing");
            //clear mon items for preview
            //for (int i = 0; i >= 5; i++)
            //{
            //    foreach (Transform child in monPanels[i].transform)
            //    {
            //        GameObject.Destroy(child.gameObject);
            //    }
            //}

            int count = 0;
            foreach (int i in monList)
            {
                if (i == int.Parse(txtnum.text))
                {
                    monList[count] = -1;
                    break;
                }
                count++;
            }
            //print("removing: " + txtnum.text);
        }

        //display mons again
        
        //imgMon1.sprite = getMonSprite(monList[0]);
        //imgMon2.sprite = getMonSprite(monList[1]);
        //imgMon3.sprite = getMonSprite(monList[2]);
        //imgMon4.sprite = getMonSprite(monList[3]);
        //imgMon5.sprite = getMonSprite(monList[4]);
        //imgMon6.sprite = getMonSprite(monList[5]);

        imgMon1.GetComponent<Image>().sprite = getMonSprite(monList[0]);
        imgMon2.GetComponent<Image>().sprite = getMonSprite(monList[1]);
        imgMon3.GetComponent<Image>().sprite = getMonSprite(monList[2]);
        imgMon4.GetComponent<Image>().sprite = getMonSprite(monList[3]);
        imgMon5.GetComponent<Image>().sprite = getMonSprite(monList[4]);
        imgMon6.GetComponent<Image>().sprite = getMonSprite(monList[5]);

        //add mons to stadium game list
        if (player == 0)
            sg.monList = monList;
        else
            sg.monList2 = monList;
    }

    private Sprite getMonSprite(int num)
    {
        Sprite sprite;
        string strNum;
        

        if (num != -1)
        {
            Mugglemon_Data mmD = MGO.mons[num].GetComponent(typeof(Mugglemon_Data)) as Mugglemon_Data;
            sprite = mmD.sprite;//MDB.MuggleDex[num].sprite;
            //num++;
            //if (num < 10)
            //    strNum = "00" + num.ToString();
            //else
            //    strNum = "0" + num.ToString();

            //print("Sprite used: " + strNum);
            //sprite = Resources.Load<Sprite>("sprites/" + strNum);
        }
        else
            sprite = null;

        return sprite;
    }
}
