using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public enum StatementDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}

public enum StatementStatus
{
    PREPARING,
    SHOWING,
    OFFSCREEN
}

[CreateAssetMenu(menuName = "Statement", fileName = "Statement")]
public class Statement : ScriptableObject
{
    public string text;
    public int weakPointStart;
    public int weakPointEnd;

    public StatementDirection directionIn = StatementDirection.LEFT;
    public StatementDirection directionOut = StatementDirection.RIGHT;

    public LeanTweenType easingStyle = LeanTweenType.easeInOutExpo;

    public Vector3 positionOnScreen;
}
