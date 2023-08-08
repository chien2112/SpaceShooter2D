using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PanelResult panelResult;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameStateManager gameStateManager;
    private void Start()
    {
        //panelResult = GameObject.FindGameObjectWithTag("PanelResult").GetComponent<PanelResult>();
        //panelPause = GameObject.FindGameObjectWithTag("PanelPause");
        gameStateManager = GameStateManager.Instance;
    }
    private void Update()
    {
        PauseCheck();
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameStateManager.GetState() == GameState.Playing)
            {
                panelPause.SetActive(true);
                gameStateManager.SetState(GameState.Pausing);
            }
            else if (gameStateManager.GetState() == GameState.Pausing)
            {
                panelPause.SetActive(false);
                gameStateManager.SetState(GameState.Playing);
            }
        }
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
