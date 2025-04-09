using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode ability;
    public override void Pressed()
    {
        Debug.Log("Pressed: " + ability.ToString());
        PlayerController.Instance.PlayerAbility.Active(ability);
    }
}
