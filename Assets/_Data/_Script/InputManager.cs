using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }
    public float OnFiring { get => onFiring;}

    [SerializeField] private float onFiring;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than 1 instance");
        }
        instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }


    private void FixedUpdate()
    {
        this.GetMousePosition();
    }

    private void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePosition()
    {
        this.mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
