using UnityEngine;

public class OnPressAlpha : ThanguMonoBehavior
{

    // Update is called once per frame
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHokeyManager.Instance.isPress1) this.Press(1);
        if (InputHokeyManager.Instance.isPress2) this.Press(2);
        if (InputHokeyManager.Instance.isPress3) this.Press(3);
        if (InputHokeyManager.Instance.isPress4) this.Press(4);
        if (InputHokeyManager.Instance.isPress5)  this.Press(5);
        if (InputHokeyManager.Instance.isPress6)  this.Press(6);
        if (InputHokeyManager.Instance.isPress7) this.Press(7);
    }

    protected virtual void Press(int press)
    {
        Debug.Log(press);
    }
}
