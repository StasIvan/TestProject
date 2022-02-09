using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveControll 
{
    IEnumerator MoveToGoal(CharacterController controller, Vector2 endPosition, float speed);
}
