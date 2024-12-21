using UnityEngine;

public class ToggleActiveWithKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode = KeyCode.None;
    [SerializeField] private GameObject objectToToggle = null;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }

    public virtual void ShowHide()
    {
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}

