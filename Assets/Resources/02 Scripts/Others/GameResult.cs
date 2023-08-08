using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameResult : MonoBehaviour
{
    private Level level;
    private Player player;
    private GameStateManager gameStateManager;
    private bool isShow;

    [SerializeField] private PanelResult panelResult;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] private TextMeshProUGUI txtCoin;

    public int coinStart;
    public int coinReceived;

    void Start()
    {
        coinStart = SavingSystem.Instance.dataPlayer.coin;
        isShow = false;
        level = FindObjectOfType<Level>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameStateManager = GameStateManager.Instance;

    }
    private void Update()
    {
        CheckingResult();
        UpdateCoinText();
    }

    void CheckingResult()
    {
        if ((gameStateManager.GetState() == GameState.Win || gameStateManager.GetState() == GameState.Lose) && !isShow)
        {
            isShow = true;
            StartCoroutine(ISoundResult());
        }
    }
    IEnumerator ISoundResult()
    {
        if(gameStateManager.GetState() == GameState.Lose)
        {
            yield return new WaitForSeconds(0.5f);
            SoundManager.Instance.PlayClip(loseClip, audioMixerGroup);
            StartCoroutine(IResult(false));
        }
        else if(gameStateManager.GetState() == GameState.Win)
        {
            yield return new WaitForSeconds(3.4f);
            SoundManager.Instance.PlayClip(winClip, audioMixerGroup);
            StartCoroutine(IResult(true));
        }
        
    }
    IEnumerator IResult(bool isWin)
    {
        if (isWin)
        {
            yield return new WaitForSeconds(winClip.length);
        }
        else if (!isWin){
            yield return new WaitForSeconds(loseClip.length);
        }
        
        if (isWin)
        {
            panelResult.txtResult.text = "WIN";
            panelResult.txtResult.color = panelResult.colorWin;
            int coin = SavingSystem.Instance.dataPlayer.coin;
            coinReceived = coin - coinStart;
            panelResult.txtCoin.text = "+" + coinReceived.ToString();
        }
        else if (!isWin)
        {
            panelResult.txtResult.text = "LOSE";
            panelResult.txtResult.color = panelResult.colorLose;
            int coin = SavingSystem.Instance.dataPlayer.coin;
            coinReceived = coin - coinStart;
            panelResult.txtCoin.text = "+" + coinReceived.ToString();
        }
        panelResult.gameObject.SetActive(true); 
    }
    public void UpdateCoinText()
    {
        txtCoin.text = SavingSystem.Instance.dataPlayer.coin.ToString();
    }
}
