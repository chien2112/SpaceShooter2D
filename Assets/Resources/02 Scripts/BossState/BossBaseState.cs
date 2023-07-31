using UnityEngine;

public abstract class BossBaseState
{
    public abstract void EnterState(BossStateManager enemy);
    public abstract void UpdateState(BossStateManager enemy);

}