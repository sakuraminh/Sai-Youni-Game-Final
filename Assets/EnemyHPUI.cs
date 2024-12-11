using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : EnemyPrefabAbs
{
    [SerializeField] protected Canvas canvas;
    public Canvas Canvas => this.canvas;

    [SerializeField] protected Slider slider;
    public Slider Slider => this.slider;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => this.mainCamera;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.UpdateSlider();
    }

    protected virtual void Update()
    {
        //this.UpdateSlider();
        this.CameraLookAt();
    }

    public virtual void UpdateSlider()
    {
        this.slider.value = this.CalculateHP();

        if (this.EnemyPrefabCtrl.EnemyDameReceive.CurrentHp >= this.EnemyPrefabCtrl.EnemyDameReceive.MaxHp)
        {
            if (this.canvas.gameObject.activeSelf == false) return;
            this.canvas.gameObject.SetActive(false);
            return;
        }
        if (this.canvas.gameObject.activeSelf == true) return;
        this.canvas.gameObject.SetActive(true);
    }
    protected virtual float CalculateHP()
    {
        //Debug.Log("EnemyHPUI: CalculateHP" + this.EnemyPrefabCtrl.EnemyDameReceive.CurrentHp / this.EnemyPrefabCtrl.EnemyDameReceive.MaxHp);
        return (float)this.EnemyPrefabCtrl.EnemyDameReceive.CurrentHp / this.EnemyPrefabCtrl.EnemyDameReceive.MaxHp;
    }

    protected virtual void CameraLookAt()
    {
        this.canvas.transform.LookAt(this.mainCamera.transform);
    }



    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCanvas();
        this.LoadSlider();
        this.LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Camera.main;
        Debug.Log(transform.name + ": LoadMainCamera", gameObject);
    }

    protected virtual void LoadCanvas()
    {
        if (this.canvas != null) return;
        this.canvas = GetComponentInChildren<Canvas>();
        Debug.Log(transform.name + ": LoadCanvas", gameObject);
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }
    #endregion
}
