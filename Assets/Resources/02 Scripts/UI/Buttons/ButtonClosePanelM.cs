using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClosePanelM : ButtonBase
{

    [SerializeField] UnityEngine.GameObject _panel;
    [SerializeField] AudioClip _music;
    [SerializeField] GameState _state;

    protected override void ClickButton()
    {
        base.ClickButton();
        _panel.SetActive(false);
        SetMusic();
        GameStateManager.Instance.SetState(_state);
    }
    public void SetMusic()
    {
        Music music = FindObjectOfType<Music>();
        music?.ChangeMusic(_music);
    }
}
