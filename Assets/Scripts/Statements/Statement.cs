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
public class Statement
{
    string text;
    int weakPointStart;
    int weakPointEnd;

    StatementDirection directionIn = StatementDirection.LEFT;
    StatementDirection directionOut = StatementDirection.RIGHT;

    LeanTweenType easingStyle = LeanTweenType.easeInOutExpo;

    Vector3 positionOnScreen;
    
    public Statement(string _text)
    {
        this.text = _text;

        this.weakPointStart = _text.IndexOf("[", 0);
        this.weakPointEnd = _text.IndexOf("]", 0);
    }
    
    
    void setDirection(StatementDirection statementDirection, int direction)
    {
        if (direction == 0)
        {
            this.directionIn = statementDirection;
            return;
        }

        this.directionOut = statementDirection;
    }
    void setPositionOnScreen(Vector3 positionOnScreen)
    {
        this.positionOnScreen = positionOnScreen;
    }

    void setEasingStyle(LeanTweenType ease)
    {
        this.easingStyle = ease;
    }

}
