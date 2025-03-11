using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public abstract class BaseText : ThanguMonoBehavior
{
    [SerializeField] protected TextMeshProUGUI txt;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadText();

    }

    protected virtual void loadText()
    {
        if (txt != null) return;
        this.txt = gameObject.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(gameObject.name + ": Loadtxt", gameObject);
    }

}
