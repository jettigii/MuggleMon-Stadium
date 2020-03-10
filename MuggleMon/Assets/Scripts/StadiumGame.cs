using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumGame : MonoBehaviour
{

    //gameplay options
    public bool playAgainstComputer;
    public int gameMode;//0 = Anything Goes, 1 = Little Cup, 2 = Big Cup

    //Helper classes
    public GameObject StadiumCameraController;
    private StadiumCameraIdleSwitcher SCIS;
    public GameObject StadiumMonAnimController;
    private StadiumMonAnims SMAC;
    public GameObject StadiumMusicController;
    private AudioSource theAudio;
    public GameObject StadiumMonsterController;
    private MonsterGameObjects MGO;
    public GameObject StadiumCanvasController;
    private StadiumCanvasComponent SCC;
    public GameObject StadiumMonScaleControllerp1;
    private lerpScale SMSCp1;
    public GameObject StadiumMonScaleControllerp2;
    private lerpScale SMSCp2;
    public GameObject StadiumMovesObjectControllerUser;
    private StadiumMovesObject SMO_User;
    public GameObject StadiumMovesObjectControllerOpp;
    private StadiumMovesObject SMO_Opp;
    public GameObject introGameObject;

    //Player data
    public GameObject Player1Position; //xyz positions for mons
    public GameObject Player2Position;

    private GameObject player1CurrentMuggleMon;
    private GameObject player2CurrentMuggleMon;
    public int selectedPlayer1MonIndex = 0;
    public int selectedPlayer2MonIndex = 0;

    public Mugglemon_Database mmDB = new Mugglemon_Database();
    private moves_Database movesDB;

    public Mugglemon_Data[] player1MuggleMon;
    public Mugglemon_Data[] player2MuggleMon;
    public int[] monList;// = { -1, -1, -1, -1, -1, -1 };
    public int[] monList2;// = { -1, -1, -1, -1, -1, -1 };

    public bool introStart;
    public bool introDone;

    public bool p1Ready = false;
    public int p1Action = 0;// 0 = move, 1 = mons, 2 = run, 3 =nothing
    public int p1move_num = 0;
    public int p1mon_num = 0;
    public bool p2Ready = false;
    public int p2Action = 0;// 0 = move, 1 = mons, 2 = run, 3 =nothing
    public int p2move_num = 0;
    public int p2mon_num = 0;

    private int firstPlayer = 0;
    private bool turnA = false;
    private bool turnB = false;

    private bool turnPlayer1ChangeMon = false;
    private bool turnPlayer2ChangeMon = false;


    //private int testCycle1 = 0;

    // Start is called before the first frame update
    void Start()
    {

        MGO = StadiumMonsterController.GetComponent(typeof(MonsterGameObjects)) as MonsterGameObjects;
        SMAC = StadiumMonAnimController.GetComponent(typeof(StadiumMonAnims)) as StadiumMonAnims;
        theAudio = StadiumMusicController.GetComponent<AudioSource>();
        SCIS = StadiumCameraController.GetComponent(typeof(StadiumCameraIdleSwitcher)) as StadiumCameraIdleSwitcher;
        SCC = StadiumCanvasController.GetComponent(typeof(StadiumCanvasComponent)) as StadiumCanvasComponent;
        SMSCp1 = StadiumMonScaleControllerp1.GetComponent(typeof(lerpScale)) as lerpScale;
        SMSCp2 = StadiumMonScaleControllerp2.GetComponent(typeof(lerpScale)) as lerpScale;
        SMO_User = StadiumMovesObjectControllerUser.GetComponent(typeof(StadiumMovesObject)) as StadiumMovesObject;
        SMO_Opp = StadiumMovesObjectControllerOpp.GetComponent(typeof(StadiumMovesObject)) as StadiumMovesObject;

        mmDB = new Mugglemon_Database();
        movesDB = new moves_Database();

        player1MuggleMon = new Mugglemon_Data[6];
        player2MuggleMon = new Mugglemon_Data[6];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (introStart)
        {
            introStart = false;
            introGameObject.active = true;
        } else if (introDone)
        {
            //SCIS.cameraSwitch(SCIS.cam09, true);
            introGameObject.active = false;
            introDone = false;
            SCIS.idle = true;

            displayPlayer1Mon(player1MuggleMon[0]);
            selectedPlayer1MonIndex = 0;
            displayPlayer2Mon(player2MuggleMon[0]);
            selectedPlayer2MonIndex = 0;

            SCC.showMonStats(player1MuggleMon[0], monList, 0);
            SCC.showMonStats(player2MuggleMon[0], monList2, 1);

            SMSCp1.growPlay();
            SMSCp2.growPlay();

        } else if (p1Ready & p2Ready)
        {
            SCIS.idle = false;

            p1Ready = false;
            p2Ready = false;
            //SCC.p1pnlReady.active = false;
            //SCC.p2pnlReady.active = false;

            //onto turn function:
            //who goes first?
            print("Both ready!");

            firstPlayer = getFirstPlayer();

            if (turnPlayer1ChangeMon)
                firstPlayer = 0;
            else if (turnPlayer2ChangeMon)
                firstPlayer = 1;

            //show gimbal
            if (firstPlayer == 0)
            {
                SCIS.zoomPlayer1Reset();
                SCIS.zoomPlayer1();
            } else
            {
                SCIS.zoomPlayer2Reset();
                SCIS.zoomPlayer2();
            }

            turnA = true;
        }
        else if (turnA)
        {
            turnA = false;
            StartCoroutine(turnStart());
        }
        else if (turnB)
        {
            StartCoroutine(turnStart());
        }





        //if (Input.GetKeyDown("space"))
        //{
        //    //Mugglemon_Data md = new Mugglemon_Data();
        //    //md.mon_num = testCycle1;

        //    displayPlayer1Mon(player1MuggleMon[testCycle1]);
        //    displayPlayer2Mon(player2MuggleMon[testCycle1]);

        //    print("test cycle: " + testCycle1.ToString());

        //    if (testCycle1 > 4)
        //        testCycle1 = 0;
        //    else
        //        testCycle1++;
        //}

    }

    private IEnumerator turnStart()
    {
        bool wasTurnB = false;

        if (turnB)
        {
            turnB = false;
            wasTurnB = true;
            if (firstPlayer == 0)
                firstPlayer = 1;
            else
                firstPlayer = 0;
            
        }

        //Cameras
        if (firstPlayer == 0)
        {
            SCIS.zoomPlayer1Reset();
            SCIS.cameraSwitch(SCIS.camZoom1, true);
        } else
        {
            SCIS.zoomPlayer2Reset();
            SCIS.cameraSwitch(SCIS.camZoom2, true);
        }

        yield return new WaitForSeconds(2);

        if (firstPlayer == 0)
        {
            SCIS.zoomPlayer1();
        } else
        {
            SCIS.zoomPlayer2();
        }

        yield return new WaitForSeconds(3);

        if (firstPlayer == 0)
        {
            SCIS.onCameraPlayer1();
        } else
        {
            SCIS.onCameraPlayer2();
        }

        //Action

        //Player 1
        if (firstPlayer == 0)
        {
            if (p1Action == 0 && !turnPlayer1ChangeMon && !turnPlayer2ChangeMon)
            {
                //create gameobject for move
                //p1move_num
                //print("Attacking with: " + mmDB.MuggleDex[player1MuggleMon[selectedPlayer1MonIndex].mon_num].possibleMoves[p1mon_num]);
                //movesDB.MoveList[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].move_num];

                int _lvl = 50;
                int _atk = mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].maxATK + player1MuggleMon[selectedPlayer1MonIndex].currentATK_MOD;
                int _pwr = movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].power;
                int _oppDef = mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].maxDEF + player2MuggleMon[selectedPlayer2MonIndex].currentDEF_MOD;
                float _effectiveness = 0;
                foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].type).weaknesses)
                {
                    if (t == movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].type)
                    {
                        _effectiveness = 1.5f;
                        break;
                    }
                }
                foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].type).resisits)
                {
                    if (t == movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].type)
                    {
                        _effectiveness = 0.8f;
                        break;
                    }
                }
                try
                {
                    foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].type2).weaknesses)
                    {
                        if (t == movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].type)
                        {
                            _effectiveness = _effectiveness + 1.5f;
                            break;
                        }
                    }
                    foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].type2).resisits)
                    {
                        if (t == movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].type)
                        {
                            _effectiveness = _effectiveness - 0.2f;
                            break;
                        }
                    }
                } catch { }
                
                int dam = calcDamage(_lvl, _atk, _pwr, _oppDef, _effectiveness);
                print("Player 1: Attacking with: " + movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].move_name);
                print("Damage = " + dam);

                if (!movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].boolSpecial)
                    SMAC.player1Animation("Attack");
                else
                    SMAC.player1Animation("Attack2");

                displayMove(movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].move_num, true, 0);

                if (dam > 0)
                {
                    
                    yield return new WaitForSeconds(2);
                    displayMove(movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].move_num, false, 0);
                    SCIS.onCameraPlayer2();
                    SMAC.player2Animation("Hit");
                }
                //apply damage
                player2MuggleMon[selectedPlayer2MonIndex].mon_health -= dam;
                SCC.showMonStats(player1MuggleMon[selectedPlayer1MonIndex], monList, 0);
                SCC.showMonStats(player2MuggleMon[selectedPlayer2MonIndex], monList2, 1);
                //apply atk def mods
                try
                {
                    player1MuggleMon[selectedPlayer1MonIndex].currentATK_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].user_atk_growth;
                    player1MuggleMon[selectedPlayer1MonIndex].currentDEF_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].user_def_growth;

                    player2MuggleMon[selectedPlayer2MonIndex].currentATK_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].opp_atk_growth;
                    player2MuggleMon[selectedPlayer2MonIndex].currentDEF_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].possibleMoves[p1move_num]].opp_def_growth;
                } catch { }
                yield return new WaitForSeconds(1);
                if (player2MuggleMon[selectedPlayer2MonIndex].mon_health < 1)
                {
                    monList2[selectedPlayer2MonIndex] = -1;
                    SMAC.player2Animation("Die");
                    SCC.showMonStats(player1MuggleMon[selectedPlayer1MonIndex], monList, 0);
                    SCC.showMonStats(player2MuggleMon[selectedPlayer2MonIndex], monList2, 1);
                    yield return new WaitForSeconds(3);
                    turnPlayer2ChangeMon = true;
                }

            } else if (p1Action == 1)
            {
                SMSCp1.sparkle.active = true;
                yield return new WaitForSeconds(0.5f);
                //clear area
                foreach (Transform child in Player1Position.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                SMSCp1.fly();
                yield return new WaitForSeconds(2);
                SMSCp1.sparkle.active = false;
                yield return new WaitForSeconds(1);
                SMSCp1.resetPOS();
                SMSCp1.sparkle.active = true;
                SMSCp1.fly2();
                yield return new WaitForSeconds(2);
                //SMSCp1.shrinkPlay();
                
                displayPlayer1Mon(player1MuggleMon[p1mon_num]);
                SMSCp1.growPlay();
                selectedPlayer1MonIndex = p1mon_num;
                SCC.showMonStats(player1MuggleMon[p1mon_num], monList, 0);
                SMAC.boolPlayer1Die = false;
                SMAC.player1Animation("Excite");
                turnPlayer1ChangeMon = false;
                SMSCp1.sparkle.active = false;

            } else if (p1Action == 2)
            {
                //run away and lose!

            } else
            {

            }
            
        }
        //Player 2
        else if (firstPlayer == 1)
        {

            if (p2Action == 0 && !turnPlayer1ChangeMon && !turnPlayer2ChangeMon)
            {
                //create gameobject for move
                //p2move_num
                //print("Attacking with: " + mmDB.MuggleDex[player2MuggleMon[selectedPlayer2MonIndex].mon_num].possibleMoves[p2mon_num]);
                //movesDB.MoveList2[mmDB.MuggleDex[mon.mon_num - 1].possibleMoves[0]].move_num];

                int _lvl = 50;
                int _atk = mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].maxATK + player2MuggleMon[selectedPlayer2MonIndex].currentATK_MOD;
                int _pwr = movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].power;
                int _oppDef = mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].maxDEF + player1MuggleMon[selectedPlayer1MonIndex].currentDEF_MOD;
                float _effectiveness = 0;
                foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].type).weaknesses)
                {
                    if (t == movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].type)
                    {
                        _effectiveness = 1.5f;
                        break;
                    }
                }
                foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].type).resisits)
                {
                    if (t == movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].type)
                    {
                        _effectiveness = 0.8f;
                        break;
                    }
                }
                try
                {
                    foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].type2).weaknesses)
                    {
                        if (t == movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].type)
                        {
                            _effectiveness = _effectiveness + 1.5f;
                            break;
                        }
                    }
                    foreach (string t in movesDB.getTypingData(mmDB.MuggleDex[monList[selectedPlayer1MonIndex]].type2).resisits)
                    {
                        if (t == movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].type)
                        {
                            _effectiveness = _effectiveness - 0.2f;
                            break;
                        }
                    }
                } catch { }
                
                int dam = calcDamage(_lvl, _atk, _pwr, _oppDef, _effectiveness);

                print("Player 2: Attacking with: " + movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].move_name);
                print("Damage = " + dam);

                try
                {
                    if (!movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].boolSpecial)
                        SMAC.player2Animation("Attack");
                    else
                        SMAC.player2Animation("Attack2");
                } catch
                {
                    SMAC.player2Animation("Attack");
                }

                displayMove(movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].move_num, false, 0);

                if (dam > 0)
                {
                    yield return new WaitForSeconds(2);
                    displayMove(movesDB.MoveList[mmDB.MuggleDex[monList2[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].move_num, false, 0);
                    SCIS.onCameraPlayer1();
                    SMAC.player1Animation("Hit");
                }
                //apply damage
                player1MuggleMon[selectedPlayer1MonIndex].mon_health -= dam;
                SCC.showMonStats(player1MuggleMon[selectedPlayer1MonIndex], monList, 0);
                SCC.showMonStats(player2MuggleMon[selectedPlayer2MonIndex], monList2, 1);
                //apply atk def mods
                try
                {
                    player2MuggleMon[selectedPlayer2MonIndex].currentATK_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].user_atk_growth;
                    player2MuggleMon[selectedPlayer2MonIndex].currentDEF_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].user_def_growth;

                    player1MuggleMon[selectedPlayer1MonIndex].currentATK_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].opp_atk_growth;
                    player1MuggleMon[selectedPlayer1MonIndex].currentDEF_MOD += movesDB.MoveList[mmDB.MuggleDex[monList[selectedPlayer2MonIndex]].possibleMoves[p2move_num]].opp_def_growth;
                } catch { }
                yield return new WaitForSeconds(1);
                if (player1MuggleMon[selectedPlayer1MonIndex].mon_health < 1)
                {
                    monList[selectedPlayer1MonIndex] = -1;
                    SMAC.player1Animation("Die");
                    SCC.showMonStats(player1MuggleMon[selectedPlayer1MonIndex], monList, 0);
                    SCC.showMonStats(player2MuggleMon[selectedPlayer2MonIndex], monList2, 1);
                    yield return new WaitForSeconds(3);
                    turnPlayer1ChangeMon = true;
                    
                }
            }
            else if (p2Action == 1)
            {
                
                SMSCp2.sparkle.active = true;
                yield return new WaitForSeconds(0.5f);
                //clear area
                foreach (Transform child in Player2Position.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                SMSCp2.fly();
                yield return new WaitForSeconds(2);
                SMSCp2.sparkle.active = false;
                yield return new WaitForSeconds(1);
                SMSCp2.resetPOS();
                SMSCp2.sparkle.active = true;
                SMSCp2.fly2();
                yield return new WaitForSeconds(2);
                displayPlayer2Mon(player2MuggleMon[p2mon_num]);
                SMSCp2.sparkle.active = false;
                
                //SMSCp2.growPlay();
                selectedPlayer2MonIndex = p2mon_num;
                SCC.showMonStats(player2MuggleMon[p2mon_num], monList2, 1);
                SMAC.boolPlayer2Die = false;
                SMAC.player2Animation("Excite");
                turnPlayer2ChangeMon = false;

            }
            else
            {
                //run away and lose!

            }

        }


        yield return new WaitForSeconds(3);
        if (!wasTurnB)
            turnB = true;
        else
        {
            SCC.p1pnlReady.active = false;
            SCC.p2pnlReady.active = false;
            SCIS.idle = true;

            if (turnPlayer1ChangeMon)
            {
                SCC.p1pnlReady.active = false;
                SCC.p2pnlReady.active = true;
                p2Action = 3;
                p2Ready = true;
                //scc disable battle button
                SCC.p1pnlBattle.enabled = false;
                SCC.p1pnlMons.onClick.Invoke();

            } else if (turnPlayer2ChangeMon)
            {
                SCC.p2pnlReady.active = false;
                SCC.p1pnlReady.active = true;
                p1Action = 3;
                p1Ready = true;
                //scc disable battle button
                SCC.p2pnlBattle.enabled = false;
                SCC.p2pnlMons.onClick.Invoke();
            }
        }
    }
    

    public int calcDamage(int aLVL, int bATK, int cPWR, int dOppDEF, float effectiveMOD)
    {
        int dam = 0;
        float zRAND = Random.Range(217F, 255F);

        //dam = ((((((2 * aLVL) / 5) + 2) * bATK * cPWR) / dOppDEF) / 50)+2)*1)*effectiveMOD / 10)*zRAND)/ 255;
        dam = (((((2 * aLVL) / 5) + 2) * bATK * cPWR) / 50) + 2 * 1;
        dam = dam / 42;

        //dam = dam * Mathf.RoundToInt(effectiveMOD);

        return dam;
    }

    public void startGame()
    {

        //populate player1 mons
        for (int i = 0; i <= 5; i++)
        {
            if (monList[i] > -1)
            {
                Mugglemon_Data mon = new Mugglemon_Data();
                //mon = mmDB.MuggleDex[monList[i]];
                mon.mon_num = mmDB.MuggleDex[monList[i]].mon_num;
                mon.mon_health = mmDB.MuggleDex[monList[i]].maxHP;
                player1MuggleMon[i] = mon;
            }
        }
        //populate player2 mons
        for (int i = 0; i <= 5; i++)
        {
            if (monList2[i] > -1)
            {
                Mugglemon_Data mon = new Mugglemon_Data();
                //mon = mmDB.MuggleDex[monList2[i]];
                mon.mon_num = mmDB.MuggleDex[monList2[i]].mon_num;
                mon.mon_health = mmDB.MuggleDex[monList2[i]].maxHP;
                player2MuggleMon[i] = mon;
            }
        }

        introStart = true;
    }

    private void displayPlayer1Mon(Mugglemon_Data mon)
    {

        //player1CurrentMuggleMon = mon.gameObject;
        
        //clear area
        foreach (Transform child in Player1Position.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        SMSCp1.sparkle.active = false;

        Vector3 tmpPos = MGO.mons[mon.mon_num - 1].transform.position;
        float tmpRot = MGO.mons[mon.mon_num - 1].transform.localRotation.y;

        player1CurrentMuggleMon = Instantiate(MGO.mons[mon.mon_num-1], new Vector3(0, 0, 0), Quaternion.identity);
        player1CurrentMuggleMon.transform.parent = Player1Position.transform;
        player1CurrentMuggleMon.transform.localPosition = tmpPos;
        player1CurrentMuggleMon.transform.Rotate(0, 180, 0);

        player1CurrentMuggleMon.transform.Rotate(0, tmpRot, 0);
        //player1CurrentMuggleMon.transform.localScale = player1CurrentMuggleMon.transform.localScale * 1;

        SMAC.player1Prefab = player1CurrentMuggleMon;
        
    }
    private void displayPlayer2Mon(Mugglemon_Data mon)
    {

        //player1CurrentMuggleMon = mon.gameObject;

        //clear area
        foreach (Transform child in Player2Position.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Vector3 tmpPos = MGO.mons[mon.mon_num - 1].transform.localPosition;
        float tmpRot = MGO.mons[mon.mon_num - 1].transform.localRotation.y;

        player2CurrentMuggleMon = Instantiate(MGO.mons[mon.mon_num-1], new Vector3(0, 0, 0), Quaternion.identity);
        player2CurrentMuggleMon.transform.parent = Player2Position.transform;
        player2CurrentMuggleMon.transform.localPosition = tmpPos;

        player2CurrentMuggleMon.transform.Rotate(0, tmpRot, 0);
        //player2CurrentMuggleMon.transform.Rotate(0, 180, 0);
        //player2CurrentMuggleMon.transform.localScale = player2CurrentMuggleMon.transform.localScale * 1;

        SMAC.player2Prefab = player2CurrentMuggleMon;
    }

    private int getFirstPlayer()
    {
        //determine based on speed
        if (player1MuggleMon[selectedPlayer1MonIndex].maxSPD > player2MuggleMon[selectedPlayer2MonIndex].maxSPD)
        {
            firstPlayer = 0;
        }
        else if (player1MuggleMon[selectedPlayer1MonIndex].maxSPD < player2MuggleMon[selectedPlayer2MonIndex].maxSPD)
        {
            firstPlayer = 1;
        }
        else if (player1MuggleMon[selectedPlayer1MonIndex].maxSPD == player2MuggleMon[selectedPlayer2MonIndex].maxSPD)
        {
            //random - coin toss
            if (Random.Range(0f, 1f) > 0.5f)
                firstPlayer = 0;
            else
                firstPlayer = 1;
        }

        //determine based on mon change
        if (p1Action == 1 && p2Action == 1)
            firstPlayer = 0;
        else if (p1Action == 1)
            firstPlayer = 0;
        else if (p2Action == 1)
            firstPlayer = 1;

        //determine based on run
        if (p1Action == 2 && p2Action == 2)
            firstPlayer = 0;//show lose screen for both
        else if (p1Action == 2)
            firstPlayer = 0;//show lose screen for player 1
        else if (p2Action == 2)
            firstPlayer = 1;//show lose screen for player 2

        print("Player " + (firstPlayer + 1) + ", is going first");

        return firstPlayer;
    }

    private void displayMove(int move_num, bool user, int player_num)
    {
        try
        {
            move_num -= 1;
            GameObject go = new GameObject();

            if (player_num == 0 && user)
            {
                go = Instantiate(SMO_User.moves[move_num], new Vector3(0, 0, 0), Quaternion.identity);
                go.transform.parent = Player1Position.transform;
            }
            else if (player_num == 0 && !user)
            {
                go = Instantiate(SMO_Opp.moves[move_num], new Vector3(0, 0, 0), Quaternion.identity);
                go.transform.parent = Player2Position.transform;
                go.transform.Rotate(0, 180, 0);
            }
            else if (player_num == 1 && user)
            {
                go = Instantiate(SMO_User.moves[move_num], new Vector3(0, 0, 0), Quaternion.identity);
                go.transform.parent = Player2Position.transform;
                go.transform.Rotate(0, 180, 0);
            }
            else if (player_num == 1 && !user)
            {
                go = Instantiate(SMO_Opp.moves[move_num], new Vector3(0, 0, 0), Quaternion.identity);
                go.transform.parent = Player1Position.transform;
            }

            go.transform.localPosition = new Vector3(0, 0, 0);

            Destroy(go, 3);
        } catch { }
    }

}
