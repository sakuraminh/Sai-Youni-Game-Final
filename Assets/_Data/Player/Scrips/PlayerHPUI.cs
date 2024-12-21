using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MMonoBehaviour
{
    [SerializeField] protected UICtrl uICtrl;

    [SerializeField] protected Slider sliderHP;
    public Slider SliderHP => this.sliderHP;

    [SerializeField] protected Slider sliderMP;
    public Slider SliderMP => this.sliderMP;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected virtual void Update()
    {
        this.UpdateSlider();
    }

    public virtual void UpdateSlider()
    {
        this.sliderHP.value = this.CalculateHP();
        this.sliderMP.value = this.CalculateMP();

    }

    protected virtual float CalculateMP()
    {
        return (float)this.uICtrl.GameCtrl.PlayerCtrl.PlayerAttack.CurrentMP / this.uICtrl.GameCtrl.PlayerCtrl.PlayerAttack.MaxMP;
    }

    protected virtual float CalculateHP()
    {
        return (float)this.uICtrl.GameCtrl.PlayerCtrl.PlayerDameReceive.CurrentHp / this.uICtrl.GameCtrl.PlayerCtrl.PlayerDameReceive.MaxHp;
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUICtrl();
    }

    protected virtual void LoadUICtrl()
    {
        if (this.uICtrl != null) return;
        this.uICtrl = GetComponentInParent<UICtrl>();
        Debug.Log(transform.name + ": LoadUICtrl", gameObject);
    }

    #endregion
}
