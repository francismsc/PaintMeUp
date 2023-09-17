using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ColorChecker : MonoBehaviour
{
    private Color objectiveColor;
    [SerializeField] private float tolerance = 0;


    private void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
    public void RandomColor()
    {
        objectiveColor = Color.blue;
       // objectiveColor = new Color(Random.value, Random.value, Random.value);

    }

    public bool AreColorsAlmostEqual(Color currentColor)
    {
        return Mathf.Abs(currentColor.r - objectiveColor.r) <= tolerance &&
               Mathf.Abs(currentColor.g - objectiveColor.g) <= tolerance &&
               Mathf.Abs(currentColor.b - objectiveColor.b) <= tolerance;
    }

    public Color GetObjectiveColor()
    {
        return objectiveColor;
    }



}
