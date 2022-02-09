using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        GameController.Instance.LoadLevel();
    }
}
