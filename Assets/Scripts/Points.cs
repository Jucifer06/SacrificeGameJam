using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI points;

    void Start()
    {
        string s = "... but you still dodged  " + StaticVariables.score.ToString() + "  arrows!";
        points.text = s;
    }
}
