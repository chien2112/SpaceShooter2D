using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PanelResult : MonoBehaviour
{
    public TextMeshProUGUI txtResult;
    public TextMeshProUGUI txtCoin;
    public Color colorWin;
    public Color colorLose;
    private void Awake()
    {
        foreach(Transform t in transform)
        {
            if(t.name == "txtResult")
            {
                txtResult = t.GetComponent<TextMeshProUGUI>();
            }
            if (t.name == "txtCoin")
            {
                txtCoin = t.GetComponent<TextMeshProUGUI>();
            }
        }
    }
}
