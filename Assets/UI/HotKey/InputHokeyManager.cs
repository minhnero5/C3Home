using UnityEngine;

public class InputHokeyManager : MonoBehaviour
{
    private static InputHokeyManager instance;
    public static InputHokeyManager Instance { get => instance; }

    public bool isPress1 = false;
    public bool isPress2 = false;
    public bool isPress3 = false;
    public bool isPress4 = false;
    public bool isPress5 = false;
    public bool isPress6 = false;
    public bool isPress7 = false;

    private void Awake()
    {
        if (InputHokeyManager.instance != null)
        {
            Debug.LogError("There is more than 1 instance");
        }
        InputHokeyManager.instance = this;
    }

    private void Update()
    {
        this.GetHotkeyPress();
    }

    protected virtual void GetHotkeyPress()
    {
        this.isPress1 = Input.GetKeyDown(KeyCode.Alpha1);
        this.isPress2 = Input.GetKeyDown(KeyCode.Alpha2);
        this.isPress3 = Input.GetKeyDown(KeyCode.Alpha3);
        this.isPress4 = Input.GetKeyDown(KeyCode.Alpha4);
        this.isPress5 = Input.GetKeyDown(KeyCode.Alpha5);
        this.isPress6 = Input.GetKeyDown(KeyCode.Alpha6);
        this.isPress7 = Input.GetKeyDown(KeyCode.Alpha7);
       
    }
}
