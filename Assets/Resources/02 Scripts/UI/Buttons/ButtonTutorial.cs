using UnityEngine;

public class ButtonTutorial : ButtonBase
{
    [SerializeField] UnityEngine.GameObject _panel;
    protected override void ClickButton()
    {
        base.ClickButton();
        _panel.SetActive(true);
        GameTutorial.Instance.NextTutorial();
    }
}
