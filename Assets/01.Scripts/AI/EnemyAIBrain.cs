using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChanged;
    public UnityEvent OnFireButtonPress;
    public UnityEvent OnFIreButtonRelease;

    [SerializeField] private AIState _currentState;

    [SerializeField] private Transform _target; //이건 나중에 게임매니저를 통해서 가져올건데, 지금은 드래그앤 드롭
    public Transform Target
    {
        get => _target;
    }

    protected void Update()
    {
        if (_target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero);
            return;
        }
        else
        {
            _currentState.UpdateState();
        }
    }

    public void ChangeState(AIState state)
    {
        _currentState = state;
    }

    public virtual void Attack()
    {
        OnFireButtonPress?.Invoke();
    }

    public void Move(Vector2 direction, Vector2 targetPos)
    {
        OnMovementKeyPress?.Invoke(direction);
        OnPointerPositionChanged?.Invoke(targetPos);
    }
}
