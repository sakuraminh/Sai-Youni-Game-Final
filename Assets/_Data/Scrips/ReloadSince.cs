#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSince : MMonoBehaviour
{
    [SerializeField] Transform backGround;
    public Transform BackGround => this.backGround;

    protected override void Start()
    {
        base.Start();
        this.DisableBackGround();
    }

    protected virtual void DisableBackGround()
    {
        if (this.backGround == null) return;
        this.backGround.gameObject.SetActive(false);
    }

    public virtual void EnableBackGround()
    {
        if (this.backGround == null) return;
        this.backGround.gameObject.SetActive(true);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackGround();
    }

    protected virtual void LoadBackGround()
    {
        if (this.backGround != null) return;
        this.backGround = transform.Find("BackGround");
        Debug.Log(transform.name + ": LoadBackGround", gameObject);
    }

    public virtual void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public virtual void ExitGame()
    {
        Application.Quit();
    }
    public virtual void StopPlayMode()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Debug.LogWarning("This function only works in Unity Editor!");
#endif
    }
}
