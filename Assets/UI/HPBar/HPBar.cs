using UnityEngine;
using UnityEngine.UI;

public class HPBar : ThanguMonoBehavior  
{
    [SerializeField] protected ShootableObjectController shootableObjectController;
    [SerializeField] protected SliderHP sliderHP;

    protected virtual void FixedUpdate()
    {
        
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
    }
    protected virtual void HPShowing()
    {
        if (this.shootableObjectController == null) return;
        float hp = this.shootableObjectController.DamageReceiver.HP;
        float maxHP = this.shootableObjectController.DamageReceiver.HPMax;

        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHP);
    }
     
    public virtual void SetObjectController(ShootableObjectController shootableObjectController)
    {
        this.shootableObjectController = shootableObjectController;
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren <SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }


}
