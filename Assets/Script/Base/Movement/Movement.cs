using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour, IMove
{
    public void Move(CharacterController character, Vector2 direction, float speed)
    {
        character.Move(direction * speed * Time.deltaTime);
    }

    public void Move(Transform character, Vector2 direction, float speed)
    {
        character.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    public void Move(Rigidbody2D rb, Vector2 direction, float speed, float maxSpeed = Mathf.Infinity)
    {
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public enum Axis { X, Y, Z, XY, XZ, YZ, ALL }

    public IEnumerator MoveToGoal(Rigidbody2D rb2D, Vector3 endPosition, float speed, Axis axis = Axis.ALL)
    {
        Transform startTransform = rb2D.transform;
        Vector3 startPosition = startTransform.position;
        Vector3 newPositions = startPosition;
        switch (axis)
        {
            case Axis.ALL:
                newPositions = endPosition;
                break;

            case Axis.X:
                newPositions = new Vector3(endPosition.x, newPositions.y, newPositions.z);
                break;
            case Axis.Y:
                newPositions = new Vector3(newPositions.x, endPosition.y, newPositions.z);
                break;
            case Axis.Z:
                newPositions = new Vector3(newPositions.x, newPositions.y, endPosition.z);
                break;

            case Axis.XY:
                newPositions = new Vector3(endPosition.x, endPosition.y, newPositions.z);
                break;
            case Axis.XZ:
                newPositions = new Vector3(endPosition.x, newPositions.y, endPosition.z);
                break;
            case Axis.YZ:
                newPositions = new Vector3(newPositions.x, endPosition.y, endPosition.z);
                break;
        }
        float percent = 0f;
        //float time = (newPositions - startPosition).sqrMagnitude / speed;
        while (percent < 1f)
        {
            startTransform.position = Vector2.Lerp(startPosition, newPositions, Easing.Linear(percent));
            //percent += time;
            percent += 1f / speed;
            yield return new WaitForFixedUpdate();
        }
    }

}
