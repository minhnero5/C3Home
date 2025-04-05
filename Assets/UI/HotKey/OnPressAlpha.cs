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
        if (InputHokeyManager.Instance.isPress1) Debug.Log("1");
        if (InputHokeyManager.Instance.isPress2) Debug.Log("2");
        if (InputHokeyManager.Instance.isPress3) Debug.Log("3");
        if (InputHokeyManager.Instance.isPress4) Debug.Log("4");
        if (InputHokeyManager.Instance.isPress5) Debug.Log("5");
        if (InputHokeyManager.Instance.isPress6) Debug.Log("6");
        if (InputHokeyManager.Instance.isPress7) Debug.Log("7");
    }
}
