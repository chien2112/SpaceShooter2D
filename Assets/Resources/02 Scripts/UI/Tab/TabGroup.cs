using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TabGroup : MonoBehaviour
{
    [SerializeField] List<TabButton> tabButtons = new List<TabButton>();
    [SerializeField] List<UnityEngine.GameObject> objectsToSwap = new List<UnityEngine.GameObject>();
    [SerializeField] TabButton selectedTab;

    [SerializeField] AudioClip clip;
    [SerializeField] AudioMixerGroup audioMixerGroup;
    private void Awake()
    {
    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
            button.transform.localScale = new Vector3(1.3f, 1.3f, 1);
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        SoundManager.Instance.PlayClip(clip, audioMixerGroup);
        int index = button.transform.GetSiblingIndex();
        for(int i = 0;i<objectsToSwap.Count;i++)
        {
            if(i == index)
                objectsToSwap[i].SetActive(true);
            else

                objectsToSwap[i].SetActive(false);
        }
    }
    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (button == selectedTab) continue;
            button.transform.localScale = new Vector3(1, 1, 1);
        }

    }

}
