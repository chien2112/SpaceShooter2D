using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    private FlyPath flyPath;
    private float flySpeed;
    private int nextIndex = 0;
    [SerializeField] private bool isRepeat;
    

    public FlyPath FlyPath { get => flyPath; set => flyPath = value; }
    public float FlySpeed { get => flySpeed; set => flySpeed = value; }
    public int NextIndex { get => nextIndex; set => nextIndex = value; }

    void Update()
    {
        if (FlyPath == null) return;

        if (NextIndex >= FlyPath.waypoints.Length && isRepeat)
        {
            NextIndex = 0;
        }

        if (transform.position != FlyPath[NextIndex])
        {
            FlyToNextWaypoint();
        }
        else
        {
            NextIndex++;
        }
    }
    private void FlyToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, FlyPath[NextIndex], FlySpeed * Time.deltaTime);
    }

}

