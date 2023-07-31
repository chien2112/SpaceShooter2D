using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyAction : Singleton<MyAction>
{
    public UnityAction updateUI;
    public UnityAction updateItem;
    public UnityAction updateScore;
    public UnityAction playerDie;
    public UnityAction buttonOnClick;

}
