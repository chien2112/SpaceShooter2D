using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class ButtonLevel : ButtonBase
{
    [SerializeField] AudioClip _music;
    [SerializeField] GameState _state;
    public LevelManager levelManager;
    private int index;

    protected override void Awake()
    {
        base.Awake();
        levelManager = UnityEngine.GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        index = transform.GetSiblingIndex();
    }
    protected override void ClickButton()
    {
        SetMusic();
        GameStateManager.Instance.SetState(_state);
        CursorManager.Instance.CursorVisible(false);
        SpawnLevel();
        SceneManager.LoadScene("Game");
        ObjectPooling.ClearDic();
    }
    public void SetMusic()
    {
        Music music = FindObjectOfType<Music>();
        music?.ChangeMusic(_music);
    }
    public void SpawnLevel()
    {
        UnityEngine.GameObject levelPrefab = levelManager.SOLevelManager.levels[index];
        UnityEngine.GameObject go = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        DontDestroyOnLoad(go);
    }
}
