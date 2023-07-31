using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    [SerializeField] GameState _state;

    private void Awake()
    {
        _state = GameState.HomeMenu;
        var result = FindObjectsOfType<GameStateManager>();
        foreach (var manager in result)
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void SetState(GameState state )
    {
        _state = state;
        if(state != GameState.Pausing)
        {
            Time.timeScale = 1;
        }
        else if (state == GameState.Pausing)
        {
            Time.timeScale = 0;
        }
    }
    public GameState GetState()
    {
        return _state;
    }
}
