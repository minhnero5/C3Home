using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than 1 instance");
        }
        instance = this;
    }
    



    private void FixedUpdate()
    {
        this.GetMousePosition();
    }

    protected virtual void GetMousePosition()
    {
        this.mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
