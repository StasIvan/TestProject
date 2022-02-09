using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseUI : GroupUI
{
    [SerializeField] private Button restartButton;

    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        GameController.Instance.OnLose -= Show;
    }

    public override void Init()
    {
        GameController.Instance.OnLose += Show;
        restartButton.onClick.AddListener(Hide);    
        base.Init();
    }

    public override void Show()
    {
        base.Show();
        restartButton.interactable = true;
    }

    public override void Hide()
    {
        base.Hide();
        restartButton.interactable = false;
        GameController.Instance.LoadLevel();
    }

    
}