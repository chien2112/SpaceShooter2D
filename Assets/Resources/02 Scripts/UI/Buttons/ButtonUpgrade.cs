using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonUpgrade : ButtonBase
{
    [SerializeField] UnityEngine.GameObject _panel;
    [SerializeField] AudioClip _music;
    [SerializeField] GameState _state;

    protected override void ClickButton()
    {
        base.ClickButton();
        _panel.SetActive(true);
        SetMusic();
        GameStateManager.Instance.SetState(_state);
    }
    public void SetMusic()
    {
        Music music = FindObjectOfType<Music>();
        music?.ChangeMusic(_music);
    }
}