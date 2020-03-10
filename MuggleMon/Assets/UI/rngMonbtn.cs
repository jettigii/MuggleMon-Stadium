using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rngMonbtn : MonoBehaviour
{

    public Button btnAdd;
    public Text txtMon;

    int[] mon_nums = { 0,1,2,3,4,5,6,7,8,9,10,11 };

    public void shuffle()
    {

        for (int t = 0; t < mon_nums.Length; t++)
        {
            int tmp = mon_nums[t];
            int r = Random.Range(t, mon_nums.Length);
            mon_nums[t] = mon_nums[r];
            mon_nums[r] = tmp;
        }

        for (int i = 0; i <= mon_nums.Length-1; i++)
        {
            txtMon.text = mon_nums[i].ToString();
            btnAdd.onClick.Invoke();
        }
    }
}
