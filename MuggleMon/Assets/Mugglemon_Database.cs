using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugglemon_Database : MonoBehaviour
{
    
    //string[] mon_name = { "Babafa", "BaDonkus", "ElBaDonk", "ChardBite", "ChardenFurter", "ChardDog", "Stubungus", "HumungusChungus", "MegaChungus", "Myrmeetle", "Myrmidon", "MutantNinjaBirtle", "Soletish" };
    //string[] mon_type = { "Leaf", "Leaf.Pixie", "Leaf.Pixie", "Flame", "Flame.Flight", "Flame.Flight", "Aqua", "Aqua", "Aqua.Kick", "Solid", "Solid", "Kick.WTF", "Aqua.WTF" };

    public List<Mugglemon_Data> MuggleDex = new List<Mugglemon_Data>();
    private Mugglemon_Data mon = new Mugglemon_Data();

    
    // Start is called before the first frame update
    public Mugglemon_Database()
    {
        //Babafa    01
        mon = new Mugglemon_Data();
        mon.mon_num = 1;mon.mon_name = "Babafa";mon.type = "Leaf";mon.type2 = "";mon.genderMaleChance = 0.5f;mon.minWeight = 10;mon.maxWeight = 20;mon.shiny = Color.green;mon.nextLevelexp = 10;
        mon.minHP = 45;mon.maxHP = 52;mon.minATK = 49;mon.maxATK = 53;mon.minDEF = 43;mon.maxDEF = 52;mon.minSPD = 40;mon.maxSPD = 50;
        mon.possibleMoves = new int[] { 0, 1, 2, 3 };mon.canEvolve = true;mon.evolutionMonNum = 2;mon.evolutionLevel = 16;
        mon.mon_desc = "As a little bab, Babafa dances to train itself for life.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //Babafa    02
        mon = new Mugglemon_Data();
        mon.mon_num = 2; mon.mon_name = "BaDonkus"; mon.type = "Leaf"; mon.type2 = "Pixie"; mon.genderMaleChance = 0.5f; mon.minWeight = 40; mon.maxWeight = 60; mon.shiny = Color.green; mon.nextLevelexp = 10;
        mon.minHP = 69; mon.maxHP = 72; mon.minATK = 59; mon.maxATK = 65; mon.minDEF = 53; mon.maxDEF = 62; mon.minSPD = 50; mon.maxSPD = 60;
        mon.possibleMoves = new int[] { 2, 4, 19, 21 }; mon.canEvolve = true; mon.evolutionMonNum = 3; mon.evolutionLevel = 32;
        mon.mon_desc = "In its earlier years of adulthood, BaDonkus twerks to ward off enemies and attract potential mates.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //Babafa    03
        mon = new Mugglemon_Data();
        mon.mon_num = 3; mon.mon_name = "ElBaDonk"; mon.type = "Leaf"; mon.type2 = "Pixie"; mon.genderMaleChance = 0.5f; mon.minWeight = 160; mon.maxWeight = 200; mon.shiny = Color.green; mon.nextLevelexp = 10;
        mon.minHP = 85; mon.maxHP = 92; mon.minATK = 75; mon.maxATK = 82; mon.minDEF = 69; mon.maxDEF = 76; mon.minSPD = 66; mon.maxSPD = 72;
        mon.possibleMoves = new int[] { 5, 22, 20, 19 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "Now grown into a full giraffe fiary, ElBaDonk bumps its donk to produce offspring so they may dance happily.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        ///////////////////////////////////////////////////////

        //ChardBite    04
        mon = new Mugglemon_Data();
        mon.mon_num = 4; mon.mon_name = "ChardBite"; mon.type = "Flame"; mon.type2 = ""; mon.genderMaleChance = 0.5f; mon.minWeight = 10; mon.maxWeight = 20; mon.shiny = Color.white; mon.nextLevelexp = 10;
        mon.minHP = 45; mon.maxHP = 52; mon.minATK = 49; mon.maxATK = 63; mon.minDEF = 53; mon.maxDEF = 52; mon.minSPD = 45; mon.maxSPD = 55;
        mon.possibleMoves = new int[] { 0, 1, 8, 11 }; mon.canEvolve = true; mon.evolutionMonNum = 5; mon.evolutionLevel = 16;
        mon.mon_desc = "A terrible experiment gone bad, Chardbite is an overmicrowaved mini dog. But that does'nt let it down. With its strong meat muscles, it'll fuck you up!";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //ChardenFurter    05
        mon = new Mugglemon_Data();
        mon.mon_num = 5; mon.mon_name = "ChardenFurter"; mon.type = "Flame"; mon.type2 = "Flight"; mon.genderMaleChance = 0.5f; mon.minWeight = 40; mon.maxWeight = 60; mon.shiny = Color.white; mon.nextLevelexp = 10;
        mon.minHP = 69; mon.maxHP = 72; mon.minATK = 59; mon.maxATK = 75; mon.minDEF = 63; mon.maxDEF = 62; mon.minSPD = 55; mon.maxSPD = 65;
        mon.possibleMoves = new int[] { 1, 8, 25, 16 }; mon.canEvolve = true; mon.evolutionMonNum = 6; mon.evolutionLevel = 32;
        mon.mon_desc = "Believing in itself so much, ChardenFurter sprouts its tiny wings and grows legs. Nothing could possibly go wrong.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //ChardDog    06
        mon = new Mugglemon_Data();
        mon.mon_num = 6; mon.mon_name = "ChardDog"; mon.type = "Flame"; mon.type2 = "Flight"; mon.genderMaleChance = 0.5f; mon.minWeight = 160; mon.maxWeight = 200; mon.shiny = Color.white; mon.nextLevelexp = 10;
        mon.minHP = 85; mon.maxHP = 92; mon.minATK = 75; mon.maxATK = 92; mon.minDEF = 109; mon.maxDEF = 76; mon.minSPD = 71; mon.maxSPD = 77;
        mon.possibleMoves = new int[] { 9, 8, 23, 26 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "Now fully grown, ChardDog grows a new found rage of every living creature due to neglect. It's rage is seemily unstoppable.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        ////////////////////////////////////////////////////////

        //Stubungus    07
        mon = new Mugglemon_Data();
        mon.mon_num = 7; mon.mon_name = "Stubungus"; mon.type = "Aqua"; mon.type2 = ""; mon.genderMaleChance = 0.5f; mon.minWeight = 10; mon.maxWeight = 20; mon.shiny = Color.yellow; mon.nextLevelexp = 10;
        mon.minHP = 35; mon.maxHP = 42; mon.minATK = 51; mon.maxATK = 56; mon.minDEF = 42; mon.maxDEF = 50; mon.minSPD = 70; mon.maxSPD = 80;
        mon.possibleMoves = new int[] { 0, 1, 7, 16 }; mon.canEvolve = true; mon.evolutionMonNum = 8; mon.evolutionLevel = 16;
        mon.mon_desc = "A little rascal of sorts, Stubungus are mischevious creatures that love water.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0.23F, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //HumungusChungus    08
        mon = new Mugglemon_Data();
        mon.mon_num = 8; mon.mon_name = "HumungusChungus"; mon.type = "Aqua"; mon.type2 = "Kick"; mon.genderMaleChance = 0.5f; mon.minWeight = 40; mon.maxWeight = 60; mon.shiny = Color.yellow; mon.nextLevelexp = 10;
        mon.minHP = 59; mon.maxHP = 62; mon.minATK = 61; mon.maxATK = 67; mon.minDEF = 53; mon.maxDEF = 62; mon.minSPD = 80; mon.maxSPD = 90;
        mon.possibleMoves = new int[] { 6, 14, 1, 2 }; mon.canEvolve = true; mon.evolutionMonNum = 9; mon.evolutionLevel = 32;
        mon.mon_desc = "Growing Stubungus lose their legs and sprout new ones, HumungusChungus is an abomination and should be killed. It likes waffles.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0.23F, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //MegaChungus    09
        mon = new Mugglemon_Data();
        mon.mon_num = 9; mon.mon_name = "MegaChungus"; mon.type = "Aqua"; mon.type2 = "Kick"; mon.genderMaleChance = 0.5f; mon.minWeight = 160; mon.maxWeight = 200; mon.shiny = Color.yellow; mon.nextLevelexp = 10;
        mon.minHP = 75; mon.maxHP = 82; mon.minATK = 77; mon.maxATK = 84; mon.minDEF = 69; mon.maxDEF = 76; mon.minSPD = 99; mon.maxSPD = 100;
        mon.possibleMoves = new int[] { 6, 13, 14, 2 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "Growing THICC, MegaChungus grows and grows. It shakes dat ass with maximum flow. Don't mess with it or it's ass may blow, oh no!";
        mon.displayScale = new Vector3(20, 20, 20);
        mon.displayPosition = new Vector3(0, 0.23F, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        ////////////////////////////////////////////////////////

        //Myrmeetle    10
        mon = new Mugglemon_Data();
        mon.mon_num = 10; mon.mon_name = "Myrmeetle"; mon.type = "Hard"; mon.type2 = "Insect"; mon.genderMaleChance = 0.7f; mon.minWeight = 1; mon.maxWeight = 5; mon.shiny = Color.red; mon.nextLevelexp = 12;
        mon.minHP = 49; mon.maxHP = 52; mon.minATK = 61; mon.maxATK = 67; mon.minDEF = 53; mon.maxDEF = 62; mon.minSPD = 30; mon.maxSPD = 40;
        mon.possibleMoves = new int[] { 10, 11, 21, 2 }; mon.canEvolve = true; mon.evolutionMonNum = 11; mon.evolutionLevel = 24;
        mon.mon_desc = "Although small, Myrmeetle is hard and ready.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        /////////////////////
        //Myrmidon    11
        mon = new Mugglemon_Data();
        mon.mon_num = 11; mon.mon_name = "Myrmidon"; mon.type = "Hard"; mon.type2 = "Insect"; mon.genderMaleChance = 0.8f; mon.minWeight = 222; mon.maxWeight = 444; mon.shiny = Color.red; mon.nextLevelexp = 12;
        mon.minHP = 65; mon.maxHP = 72; mon.minATK = 80; mon.maxATK = 87; mon.minDEF = 89; mon.maxDEF = 91; mon.minSPD = 60; mon.maxSPD = 64;
        mon.possibleMoves = new int[] { 12, 11, 10, 1 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "In a terrible experiment gone right, Myrmidon is a titan of power. Ready to blast anything you command.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.mon_gameObject = new GameObject();
        mon.displayPosition = new Vector3(0, 0, 0);
        MuggleDex.Add(mon);
        ////////////////////////////////////////////////////////

        //MutantNinjaBirtle    12
        mon = new Mugglemon_Data();
        mon.mon_num = 12; mon.mon_name = "MutantNinjaBirtle"; mon.type = "Neutral"; mon.type2 = ""; mon.genderMaleChance = 0.8f; mon.minWeight = 222; mon.maxWeight = 444; mon.shiny = Color.magenta; mon.nextLevelexp = 11;
        mon.minHP = 45; mon.maxHP = 52; mon.minATK = 50; mon.maxATK = 57; mon.minDEF = 39; mon.maxDEF = 41; mon.minSPD = 50; mon.maxSPD = 64;
        mon.possibleMoves = new int[] { 18, 17, 14, 23 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "A bird mutated with frog and ninja turtle DNA, MutantNinjaBirtle can perform flawless acrobatics. It is said to have strength.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        ////////////////////////////////////////////////////////
        //Soletish    13
        mon = new Mugglemon_Data();
        mon.mon_num = 13; mon.mon_name = "Soletish"; mon.type = "Neutral"; mon.type2 = "WTF"; mon.genderMaleChance = 0.8f; mon.minWeight = 222; mon.maxWeight = 444; mon.shiny = Color.yellow; mon.nextLevelexp = 11;
        mon.minHP = 45; mon.maxHP = 52; mon.minATK = 40; mon.maxATK = 50; mon.minDEF = 39; mon.maxDEF = 41; mon.minSPD = 45; mon.maxSPD = 47;
        mon.possibleMoves = new int[] { 0, 1, 7, 17 }; mon.canEvolve = false; mon.evolutionMonNum = -1; mon.evolutionLevel = -1;
        mon.mon_desc = "Weird, Soletish is a foot fish.";
        mon.displayScale = new Vector3(1, 1, 1);
        mon.displayPosition = new Vector3(0, 0, 0);
        mon.mon_gameObject = new GameObject();
        MuggleDex.Add(mon);
        ////////////////////////////////////////////////////////
    }

}
