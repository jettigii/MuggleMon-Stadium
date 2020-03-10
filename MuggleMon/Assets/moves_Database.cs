using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moves_Database : MonoBehaviour
{

    public List<moves_Data> MoveList = new List<moves_Data>();
    private moves_Data mov = new moves_Data();

    public typing_Database ttDB;
    public typing_data getTypingData(string type)
    {
        return ttDB.getTyping(type);
    }

    public moves_Database()
    {

        ttDB = new typing_Database();

        //01 
        mov = new moves_Data();
        mov.move_num = 1;
        mov.move_name = "Bam";
        mov.type = "Neutral";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user pumples its target with maximum ferocity!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //02 
        mov = new moves_Data();
        mov.move_num = 2;
        mov.move_name = "Bash";
        mov.type = "Neutral";
        mov.power = 60;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user bashes its target with vigour!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //03 
        mov = new moves_Data();
        mov.move_num = 3;
        mov.move_name = "Twerk Whip";
        mov.type = "Neutral";
        mov.power = 1;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 3;
        mov.opp_def_growth = -6;
        mov.desc = "The user twerks to lower its targets defenses while also making it eagerly want some of that raising its targets attack.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////

        //04
        mov = new moves_Data();
        mov.move_num = 4;
        mov.move_name = "Sproutage";
        mov.type = "Leaf";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user sprouts outward in an attempt to harm its target.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //05
        mov = new moves_Data();
        mov.move_num = 5;
        mov.move_name = "Leaf Slap";
        mov.type = "Leaf";
        mov.power = 60;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user slaps its foliage across its targets face.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////

        //06
        mov = new moves_Data();
        mov.move_num = 6;
        mov.move_name = "Grass stomp";
        mov.type = "Leaf";
        mov.power = 80;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user stomps on its target with its foliage!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //07
        mov = new moves_Data();
        mov.move_num = 7;
        mov.move_name = "Water Yeet";
        mov.type = "Aqua";
        mov.power = 80;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user yeets water at its target in a powerful vortex!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //08
        mov = new moves_Data();
        mov.move_num = 8;
        mov.move_name = "Aqua Kobe";
        mov.type = "Aqua";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user kobes water in an attempt to harm its target.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //09
        mov = new moves_Data();
        mov.move_num = 9;
        mov.move_name = "Hot Tamale";
        mov.type = "Flame";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user hurls spicy meatballs in an attempt to harm its target.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //10
        mov = new moves_Data();
        mov.move_num = 10;
        mov.move_name = "Burnade";
        mov.type = "Flame";
        mov.power = 90;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user burns its target with a flaming vortex of fire!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //11
        mov = new moves_Data();
        mov.move_num = 11;
        mov.move_name = "Nibble Jibblets";
        mov.type = "Insect";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user nibbles the targets jibblets.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //12
        mov = new moves_Data();
        mov.move_num = 12;
        mov.move_name = "Harden Up";
        mov.type = "Hard";
        mov.power = 0;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 3;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user gets hard! and raises its defenses.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //13
        mov = new moves_Data();
        mov.move_num = 13;
        mov.move_name = "Missile Punch";
        mov.type = "Hard";
        mov.power = 80;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user throws a punch at blazing speeds at its target!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //14
        mov = new moves_Data();
        mov.move_num = 14;
        mov.move_name = "THICC Rush";
        mov.type = "Kick";
        mov.power = 100;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = -3;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user hurls itself at its target, using its thiccness as its core strength. Power is determined by how T H I C C the user is.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //15
        mov = new moves_Data();
        mov.move_num = 15;
        mov.move_name = "Drop Kick";
        mov.type = "Kick";
        mov.power = 60;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user drops down on its target with a kick.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //16
        mov = new moves_Data();
        mov.move_num = 16;
        mov.move_name = "Kick";
        mov.type = "Kick";
        mov.power = 30;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user kicks its target.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //17
        mov = new moves_Data();
        mov.move_num = 17;
        mov.move_name = "Whap";
        mov.type = "Kick";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user whaps its target with power of fight.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //18
        mov = new moves_Data();
        mov.move_num = 18;
        mov.move_name = "Chomp";
        mov.type = "WTF";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user bites on its target. Ow!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //19
        mov = new moves_Data();
        mov.move_num = 19;
        mov.move_name = "Shank";
        mov.type = "WTF";
        mov.power = 80;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user shanks its target from behind!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //20
        mov = new moves_Data();
        mov.move_num = 20;
        mov.move_name = "Foot Massage";
        mov.type = "Pixie";
        mov.power = 0;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = -3;
        mov.desc = "The user gives its target a sensual foot massage. Lowering their defenses.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //21
        mov = new moves_Data();
        mov.move_num = 21;
        mov.move_name = "Seduce";
        mov.type = "Pixie";
        mov.power = 0;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = -3;
        mov.opp_def_growth = 0;
        mov.desc = "The user macks on its target in an attempt to seduce them. Lowering their attack.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //22
        mov = new moves_Data();
        mov.move_num = 22;
        mov.move_name = "Hug";
        mov.type = "Pixie";
        mov.power = 0;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user hugs its target hightening their self esteem. Raises users defenses.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //23
        mov = new moves_Data();
        mov.move_num = 23;
        mov.move_name = "AssQuake";
        mov.type = "Pixie";
        mov.power = 90;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user creates an earthquake with the slap of its ass claps!";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //24
        mov = new moves_Data();
        mov.move_num = 24;
        mov.move_name = "Aerial Sheen";
        mov.type = "Flight";
        mov.power = 60;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = -3;
        mov.desc = "The user flys down and shoves Charlie Sheen into its target painfully. Also lowers targets defenses.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //25
        mov = new moves_Data();
        mov.move_num = 25;
        mov.move_name = "Strangulate";
        mov.type = "Flight";
        mov.power = 40;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user strangles its target.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////
        //26
        mov = new moves_Data();
        mov.move_num = 26;
        mov.move_name = "Wind Whip";
        mov.type = "Flight";
        mov.power = 40;
        mov.speed = 2;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = 0;
        mov.opp_def_growth = 0;
        mov.desc = "The user whips its broken wind into its targets face. This moves always goes first.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = true;

        MoveList.Add(mov);
        //////////////////////
        //27
        mov = new moves_Data();
        mov.move_num = 27;
        mov.move_name = "Constraintache";
        mov.type = "Flight";
        mov.power = 0;
        mov.speed = 1;
        mov.user_atk_growth = 0;
        mov.user_def_growth = 0;
        mov.opp_atk_growth = -4;
        mov.opp_def_growth = 0;
        mov.desc = "The user constrains its target 50 shades of grey style. Lowers targets attack.";
        mov.effect_visual = "";
        mov.effect_sound = "";
        mov.time_duration = 5;
        mov.effect = new GameObject();
        mov.boolSpecial = false;

        MoveList.Add(mov);
        //////////////////////

    }
}
