using UnityEngine;
using UnityEngine.UI;

public class HPBar : ThanguMonoBehavior  
{
    [SerializeField] protected ShootableObjectController shootableObjectController;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;

    protected virtual void FixedUpdate()
    {
        
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
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

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren <SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }

}
