using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTutorial : Singleton<GameTutorial>
{
    public GameObject arrowTutorialHolder;
    public GameObject blockHolder;
    private void Start()
    {
        arrowTutorialHolder = GameObject.FindGameObjectWithTag("ArrowTutorialHolder");
        blockHolder = GameObject.FindGameObjectWithTag("BlockHolder");
        if (SavingSystem.Instance.dataPlayer.isNewPlayer)
        {
            arrowTutorialHolder.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void NextTutorial()
    {
        if (SavingSystem.Instance.dataPlayer.isNewPlayer)
        {
            foreach (Transform t in arrowTutorialHolder.transform)
            {
                if (t.gameObject.activeSelf)
                {
                    t.gameObject.SetActive(false);
                    int index = t.gameObject.transform.GetSiblingIndex();
                    if (index == arrowTutorialHolder.transform.childCount-1)
                    {
                        foreach (Transform block in blockHolder.transform)
                        {
                            block.gameObject.SetActive(false);
                        }
                        return;
                    }
                    arrowTutorialHolder.transform.GetChild(index + 1).gameObject.SetActive(true);
                    return;
                }
            }
            
        }
    }
}
