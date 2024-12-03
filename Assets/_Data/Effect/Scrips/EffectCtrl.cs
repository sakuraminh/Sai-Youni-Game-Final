using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : MMonoBehaviour
{
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => this.effectSpawner;

    [SerializeField] protected EffectPrefab effectPrefab;
    public EffectPrefab EffectPrefab => this.effectPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectCtrl();
        this.LoadEffectPrefab();
    }
    protected virtual void LoadEffectCtrl()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = this.GetComponentInChildren<EffectSpawner>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }
    protected virtual void LoadEffectPrefab()
    {
        if (this.effectPrefab != null) return;
        this.effectPrefab = this.GetComponentInChildren<EffectPrefab>();
        Debug.Log(transform.name + ": LoadEffectPrefab", gameObject);
    }
}
