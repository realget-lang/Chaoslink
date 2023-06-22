using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatementManager : MonoBehaviour
{
    public Dictionary<StatementDirection, Vector3> offscreen
        = new Dictionary<StatementDirection, Vector3>()
        {
            { StatementDirection.LEFT , new Vector3(-600, 0, 0) },
            { StatementDirection.RIGHT , new Vector3(900, 0, 0) },
            { StatementDirection.UP , new Vector3(150, 375, 0) },
            { StatementDirection.DOWN , new Vector3(150, -325, 0) }
        };

    public Canvas canvas;
    public Statement statementTest;
    public GameObject defaultStatement;

    void Start()
    {
        print(offscreen[StatementDirection.LEFT]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject curStatement = setupStatement(statementTest);
            showStatement(curStatement, statementTest);
            StartCoroutine(showStatement(curStatement, statementTest));
        }
    }
    GameObject setupStatement(Statement myStatement)
    {
        GameObject newStatementObject = Instantiate(defaultStatement);
        newStatementObject.transform.SetParent(canvas.transform, false);
        newStatementObject.GetComponent<TMPro.TextMeshProUGUI>().text = myStatement.text;
        RectTransform rectTransform = newStatementObject.GetComponent<RectTransform>();
        rectTransform.localPosition = offscreen[myStatement.directionIn];

        return newStatementObject;
    }

    IEnumerator showStatement(GameObject statementObject, Statement statement)
    {
        Vector3 posOnScreen = statement.positionOnScreen;
        Vector3 posExit = offscreen[statement.directionOut];

        statementObject.LeanMoveLocal(posOnScreen, 0.5f).setEase(statement.easingStyle);
        yield return new WaitForSeconds(2f);
        statementObject.LeanMoveLocal(posExit, 0.5f).setEase(statement.easingStyle);
        yield return new WaitForSeconds(0.5f);
        Destroy(statementObject);
    }
}
