using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : ThanguMonoBehavior
{
    [SerializeField] protected Slider slider;


    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void FixedUpdate()
    {
        //for override
    }

    protected virtual void AddOnClickEvent()
    {

        this.slider.onValueChanged.AddListener(this.OnValueChanged);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadSlider();

    }

    protected virtual void loadSlider()
    {
        if (slider != null) return;
        this.slider = gameObject.GetComponent<Slider>();
        Debug.Log(gameObject.name + ": LoadSlider", gameObject);
    }

    protected abstract void OnValueChanged(float newValue);
}
