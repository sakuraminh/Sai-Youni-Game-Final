using UnityEngine;

public class Helper : MMonoBehaviour
{
    [SerializeField] protected RandomPointOnNavMesh randomPointOnNavMesh;
    public RandomPointOnNavMesh RandomPointOnNavMesh => this.randomPointOnNavMesh;

    [SerializeField] protected InputManage inputManage;
    public InputManage InputManage => this.inputManage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRandomPointOnNavMesh();
        this.LoadInputManage();
    }
    protected virtual void LoadRandomPointOnNavMesh()
    {
        if (this.randomPointOnNavMesh != null) return;
        this.randomPointOnNavMesh = GetComponentInChildren<RandomPointOnNavMesh>();
        Debug.Log(transform.name + ": LoadRandomPointOnNavMesh", gameObject);
    }

    protected virtual void LoadInputManage()
    {
        if (this.inputManage != null) return;
        this.inputManage = GetComponentInChildren<InputManage>();
        Debug.Log(transform.name + ": LoadInputManage", gameObject);
    }
}
