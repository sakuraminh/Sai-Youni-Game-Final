public class PlayerRadar : Radar<EnemyCheck>
{
    public virtual bool EnemyInAttackRange()
    {
        return this.targetNearest != null;
    }
}
