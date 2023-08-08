using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : ButtonBase
{
    [SerializeField] UnityEngine.GameObject _panel;
    [SerializeField] GameState _state;

    protected override void ClickButton()
    {
        base.ClickButton();
        if (PlayCheck.Instance.Check())
        {
            _panel.SetActive(true);
            GameStateManager.Instance.SetState(_state);
            SavingSystem.Instance.dataPlayer.isNewPlayer = false;
            SavingSystem.Instance.SaveData();
        }
        else
        {
            PlayCheck.Instance.Notification();
        }
    }
}
