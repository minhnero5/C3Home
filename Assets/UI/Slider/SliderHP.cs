using UnityEngine;
using UnityEngine.UI;

public class SliderHP: BaseSlider  
{
    [SerializeField] protected float maxHP = 1;
    [SerializeField] protected float currentHP = 1;
    protected override void OnValueChanged(float newValue)
    {
        //Debug.Log("newValue: " + newValue);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }

    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }

    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP  = currentHP;
    }
}
