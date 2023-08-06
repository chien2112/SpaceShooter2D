using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        isShow = false;
        level = FindObjectOfType<Level>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameStateManager = GameStateManager.Instance;

    }
    private void Update()
    {
        CheckingResult();
    }
    void CheckingResult()
    {
        if (gameStateManager.GetState() == GameState.Win && !isShow)
        {
            isShow = true;
            panelResult.txtResult.text = "WIN";
            panelResult.txtResult.color = panelResult.colorWin;
            panelResult.txtCoin.text = "0 bit";
            StartCoroutine(ISoundResult());
        }
        if(gameStateManager.GetState() == GameState.Lose && !isShow)
        {
            isShow = true;
            panelResult.txtResult.text = "LOSE";
            panelResult.txtResult.color = panelResult.colorLose;
            panelResult.txtCoin.text = "0 bit";         
            StartCoroutine(ISoundResult());
        }
    }
    IEnumerator ISoundResult()
    {
        yield return new WaitForSeconds(4f);
        if(gameStateManager.GetState() == GameState.Lose)
        {
            //SoundManager.Instance.PlayClip(loseClip, audioMixerGroup);
            StartCoroutine(IResult(false));
        }
        else if(gameStateManager.GetState() == GameState.Win)
        {
            //SoundManager.Instance.PlayClip(winClip, audioMixerGroup);
            StartCoroutine(IResult(true));
        }
        
    }
    IEnumerator IResult(bool isWin)
    {
        yield return new WaitForSeconds(winClip.length+0.5f);
        panelResult.gameObject.SetActive(true); 
    }
}
