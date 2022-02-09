using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private int _countToVictory, _countToLose;

    private int _countFriends = 0, _countEnemies = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringContainer.friend))
        {
            _countFriends = IncreaseScore(_countFriends);
            CheckVictory();
        }
        else
        {
            _countEnemies = IncreaseScore(_countEnemies);
            CheckLose();
        }
    }

    private int IncreaseScore(int score)
    {
        return score += 1;
    }

    private void CheckVictory()
    {
        if (_countFriends >= _countToVictory)
        {
            GameController.Instance.LevelEnd(true);
        }
    }

    private void CheckLose()
    {
        if (_countEnemies >= _countToLose)
        {
            GameController.Instance.LevelEnd(false);
        }
    }
}
