using UnityEngine;

public class ButtonClosePanel : ButtonBase
{
    
    [SerializeField] UnityEngine.GameObject _panel;
    [SerializeField] GameState _state;

    protected override void ClickButton()
    {
        base.ClickButton();
        CursorManager.Instance.CursorVisible(false);
        GameStateManager.Instance.SetState(_state);
        _panel.SetActive(false);
    }
}
