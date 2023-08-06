using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : ButtonBase
{
    [SerializeField] AudioClip _music;
    [SerializeField] GameState _state;
    
    protected override void ClickButton()
    {
        base.ClickButton();
        SetMusic();
        SavingSystem.Instance.SaveData();
        GameStateManager.Instance.SetState(_state);
        SceneManager.LoadScene("Menu");
    }
    public void SetMusic()
    {
        Music music = FindObjectOfType<Music>();
        music?.ChangeMusic(_music);
    }

}
