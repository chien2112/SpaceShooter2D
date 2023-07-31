using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    PanelResult panelResult;
    private void Awake()
    {
        panelResult = GameObject.FindGameObjectWithTag("PanelResult").GetComponent<PanelResult>();
    }
    public void UpdatePanelResult(string coin, string result)
    {
        if (panelResult == null) return;
        panelResult.txtCoin.text = "+" + coin;
        panelResult.txtResult.text = result.ToUpper();
        if (panelResult.txtResult.text == "WIN")
        {
            panelResult.txtResult.color = panelResult.colorWin;
        }
        else
        {
            panelResult.txtResult.color = panelResult.colorLose;
        }
    }
}
