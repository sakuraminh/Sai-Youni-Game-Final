using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected Rigidbody rb;
    public Rigidbody Rigidbody => this.rb;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => this.mainCamera;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadRigidbody();
        this.LoadMainCamera();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    protected virtual void LoadMainCamera()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        if (mainCamera != null) return;
        this.mainCamera = Camera.main;
        Debug.Log(transform.name + ": LoadMainCamera", gameObject);
    }
}
