using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class CharacterMove : Movement
{
    [SerializeField] private float _speed;
    [SerializeField] private TypeMove _typeMove;

    [HideInInspector] public Transform thisTransform;

    private int _randomRange = 2;
    private float _maxSpeed = 2.5f;
    private float _waitSidewayMove = 1f;
    private Rigidbody2D _rb2D;
    private Coroutine _sidewaysCoroutine;

    private void Awake()
    {
        thisTransform = transform;
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (_typeMove == TypeMove.ForwardAndSideways)
        {
            _sidewaysCoroutine = StartCoroutine(MoveSideways());
        }
    }

    private void OnDisable()
    {
        if (_sidewaysCoroutine != null)
        {
            StopCoroutine(_sidewaysCoroutine);
            _sidewaysCoroutine = null;
        }
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Move(_rb2D, Vector2.down, _speed, _maxSpeed);
    }

    private IEnumerator MoveSideways()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitSidewayMove);
            int targetX = GetNextPosition();
            if (targetX - thisTransform.position.x < 0.1f)
                continue;
            Vector2 targetPosition = new Vector2(targetX, thisTransform.position.y - _maxSpeed);  
            yield return StartCoroutine(MoveToGoal(_rb2D, targetPosition, _speed, Axis.XY));
        }
    }

    private int GetNextPosition()
    {
        return Mathf.Clamp(Random.Range(-_randomRange, _randomRange) * 2, -_randomRange, _randomRange); 
    }    

    private enum TypeMove
    {
        OnlyForward,
        ForwardAndSideways
    }
}
