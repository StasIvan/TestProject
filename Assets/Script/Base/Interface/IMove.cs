using UnityEngine;
using UnityEngine.AI;

public interface IMove
{
    void Move(CharacterController character, Vector2 direction, float speed);
    //void Move(Rigidbody rb, Vector2 direction, float speed);
    //void Move(Transform transform, Vector3 direction, float speed);
}