using UnityEngine;

public class ButtonQuit : ButtonBase
{
    protected override void ClickButton()
    {
        base.ClickButton();
        QuitGame();
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

