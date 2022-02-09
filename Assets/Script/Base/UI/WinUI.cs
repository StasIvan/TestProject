using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : GroupUI
{
    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        GameController.Instance.OnVictory -= Show;
    }

    public override void Init()
    {
        GameController.Instance.OnVictory += Show;
        base.Init();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
