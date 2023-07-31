using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayer", menuName = "SO/Player")]
public class SOPlayer : ScriptableObject
{
    public float health;
    public float moveSpeed;
    public float extraSpeedMultiplier;

    public List<Weapon> weapons;
}   
