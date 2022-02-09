using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupUI : MonoBehaviour
{
    [SerializeField] private bool hideOnInit;
    [SerializeField] private GameObject content;
        
    public virtual void Init()
    {
        if (hideOnInit)
        {
            content.SetInactive();
        }
    }

    public virtual void Show()
    {
        content.SetActive();
    }

    public virtual void Hide()
    {
        content.SetInactive();
    }
}
