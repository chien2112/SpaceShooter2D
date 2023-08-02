using UnityEngine;

public class ButtonSettings : ButtonBase
{
    [SerializeField] UnityEngine.GameObject _panel;
    [SerializeField] GameState _state;

    protected override void ClickButton()
    {
        base.ClickButton();
        CursorManager.Instance.CursorVisible(true);
        _panel.SetActive(true);
        GameStateManager.Instance.SetState(_state);
    }
}
