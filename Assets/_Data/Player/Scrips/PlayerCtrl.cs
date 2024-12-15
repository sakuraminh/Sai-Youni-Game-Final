using UnityEngine;

public class PlayerCtrl : MMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected Rigidbody rb;
    public Rigidbody Rigidbody => this.rb;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => this.mainCamera;

    [SerializeField] protected PlayerMoving playerMoving;
    public PlayerMoving PlayerMoving => this.playerMoving;

    [SerializeField] protected PlayerRadar playerRadar;
    public PlayerRadar PlayerRadar => this.playerRadar;

    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => this.gameCtrl;

    [SerializeField] protected PlayerSelect playerSelect;
    public PlayerSelect PlayerSelect => this.playerSelect;

    [SerializeField] protected PlayerDameReceive playerDameReceive;
    public PlayerDameReceive PlayerDameReceive => this.playerDameReceive;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadRigidbody();
        this.LoadMainCamera();
        this.LoadPlayerMoving();
        this.LoadPlayerRadar();
        this.LoadGameCtrl();
        this.LoadPlayerSelect();
        this.LoadPlayerDameReceive();
    }

    protected virtual void LoadPlayerSelect()
    {
        if (this.playerSelect != null) return;
        this.playerSelect = GetComponentInChildren<PlayerSelect>();
        Debug.Log(transform.name + ": LoadPlayerSelect", gameObject);
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }

    protected virtual void LoadPlayerRadar()
    {
        if (this.playerRadar != null) return;
        this.playerRadar = GetComponentInChildren<PlayerRadar>();
        Debug.Log(transform.name + ": LoadPlayerRadar", gameObject);
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
    protected virtual void LoadPlayerMoving()
    {
        if (this.playerMoving != null) return;
        this.playerMoving = GetComponentInChildren<PlayerMoving>();
        Debug.Log(transform.name + ": LoadPlayerMoving", gameObject);
    }

    protected virtual void LoadPlayerDameReceive()
    {
        if (this.playerDameReceive != null) return;
        this.playerDameReceive = GetComponentInChildren<PlayerDameReceive>();
        Debug.Log(transform.name + ": LoadPlayerDameReceive", gameObject);
    }
    #endregion
}
