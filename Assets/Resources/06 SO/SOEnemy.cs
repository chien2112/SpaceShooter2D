using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SOEnemy", menuName = "SO/Enemy")]
public class SOEnemy : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
    public float flySpeed;
    public string path;
    public string enemyName;

    public AudioClip dieClip;
    public AudioMixerGroup audioMixerGroup;
    public Sprite phase2Sprite;
    public Sprite sprite;
    public GameObject bulletPrefab;

    public List<GameObject> droppedItems = new List<GameObject>();
}
