using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private StateCharacter stateCharacter;

    private void OnEnable()
    {
        SetIsAlive();
    }

    private void OnDisable()
    {
        SetIsDead();
    }

    private void OnMouseDown()
    {
        if (stateCharacter == StateCharacter.Alive)
        {
            if (gameObject.CompareTag(StringContainer.friend))
            {
                GameController.Instance.LevelEnd(false);
            }
            gameObject.SetInactive();
        }
    }

    private void SetIsAlive()
    {
        stateCharacter = StateCharacter.Alive;
    }

    private void SetIsDead()
    {
        stateCharacter = StateCharacter.Dead;
    }

    private enum StateCharacter
    {
        Alive,
        Dead
    }
}
