using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : ThanguMonoBehavior
{
    [SerializeField] protected Button button;


    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {

        this.button.onClick.AddListener(this.OnClick);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadButton();

    }

    protected virtual void loadButton()
    {
        if (button != null) return;
        this.button = gameObject.GetComponent<Button>();
        Debug.Log(gameObject.name + ": LoadButton", gameObject);
    }

    protected abstract void OnClick();
}
