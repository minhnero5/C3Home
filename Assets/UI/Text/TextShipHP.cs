using UnityEngine;
using UnityEngine.PlayerLoop;

public class TextShipHP : BaseText
{
   protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        //this.txt.SetText();
        //ShipController.
        int hpMax = PlayerController.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerController.Instance.CurrentShip.DamageReceiver.HP;
        this.txt.SetText(hp + "/" + hpMax);
    }
}
