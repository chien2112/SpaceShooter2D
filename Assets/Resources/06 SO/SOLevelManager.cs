using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "SO/Level")]
public class SOLevelManager : ScriptableObject
{
    public List<GameObject> levels = new List<GameObject>();
}
