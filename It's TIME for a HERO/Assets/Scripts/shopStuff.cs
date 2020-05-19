using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopStuff : MonoBehaviour
{
    public static string Item1;
    public static string Item2;
    public static string Item3;
    public static string Item4;

    public static int shopNumber;





    // Update is called once per frame
    void Update()
    {

        if (shopNumber == 1)
        {
            Item1 = "Leather Helm: 100C";
            Item2 = "Steel Helm: 150C";
            Item3 = "Diamond Helm: 250C";
            Item4 = "Rainbow Helm: 500C";


        }
    }
}
