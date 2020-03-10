using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typing_Database : MonoBehaviour
{
    public List<typing_data> TypeList = new List<typing_data>();
    private typing_data type = new typing_data();

    public typing_data getTyping(string typ)
    {
        foreach (typing_data data in TypeList)
        {
            if (data.type_name == typ)
                return data;
        }
        return null;
    }

    public typing_Database()
    {
        type = new typing_data();
        type.type_name = "Leaf";
        type.type_color = new Color(39f / 255f,196f / 8f, 0f);
        type.weaknesses = new string[] { "Flame", "Flight", "Insect"};
        type.resisits = new string[] { "Aqua"};
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Pixie";
        type.type_color = new Color(196f / 255f,8f / 255f,130f / 255f);
        type.weaknesses = new string[] { "Hard"};
        type.resisits = new string[] { "Fight", "Insect", "WTF" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Flame";
        type.type_color = Color.red;
        type.weaknesses = new string[] { "Aqua"};
        type.resisits = new string[] { "Insect", "Hard", "Flame", "Leaf" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Flight";
        type.type_color = new Color(146f / 255f,8f / 255f,196f / 255f);
        type.weaknesses = new string[] { "Flame"};
        type.resisits = new string[] { "Kick", "Insect","Leaf" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Aqua";
        type.type_color = Color.blue;
        type.weaknesses = new string[] { "Leaf"};
        type.resisits = new string[] { "Hard", "Flame", "Water" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Kick";
        type.type_color = new Color(222f / 255f, 88f / 255f, 7f / 255f);
        type.weaknesses = new string[] { "Flight", "Pixie"};
        type.resisits = new string[] { "Insect", "WTF" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Hard";
        type.type_color = new Color(77f / 255f, 77f / 255f, 77f / 255f);
        type.weaknesses = new string[] { "Kick", "Flame" };
        type.resisits = new string[] { "Neutral", "Flight", "Insect", "Hard", "Leaf", "Pixie" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Insect";
        type.type_color = new Color(100f / 255f, 168f / 255f, 0f);
        type.weaknesses = new string[] { "Flight", "Flame" };
        type.resisits = new string[] { "Kick", "Leaf" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "Neutral";
        type.type_color = new Color(133f / 255f, 133f / 255f, 133f / 255f);
        type.weaknesses = new string[] { "Kick"};
        type.resisits = new string[] { "WTF" };
        TypeList.Add(type);

        type = new typing_data();
        type.type_name = "WTF";
        type.type_color = Color.black;
        type.weaknesses = new string[] { "Kick", "Pixie", "Insect" };
        type.resisits = new string[] { "WTF" };
        TypeList.Add(type);

    }
}
