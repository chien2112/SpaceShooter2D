using UnityEngine;

public class ButtonTutorial : ButtonBase
{
    [SerializeField] UnityEngine.GameObject _panel;
    protected override void ClickButton()
    {
        base.ClickButton();
        CursorManager.Instance.CursorVisible(true);
        _panel.SetActive(true);
    }
}
