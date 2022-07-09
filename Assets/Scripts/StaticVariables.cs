using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static int score;

    public static bool easyMode;

    public static int life;
    public static int maxLife = 3;


    public static List<char> letters = new List<char> { 'A', 'B' , 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

    public static char[] commonLetters = { 'A', 'E', 'I', 'O', 'R', 'T', 'S' };

    public enum RULE{ typeTwice, dontType, reverse, writeLastFirst, swap};
    public static List<(string, RULE)> currentRules;

    static public void EasyMode() {
        easyMode = true;
    }

    static public void HardMode()
    {
        easyMode = false;
    }

    private void Start()
    {
        easyMode = false;
    }
}
