using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGameScene : MonoBehaviour
{
    public Text points;

    void Update()
    {
        points.text = "Points: " + StaticVariables.score;
    }
}
