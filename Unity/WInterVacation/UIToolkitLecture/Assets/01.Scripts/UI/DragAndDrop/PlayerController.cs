using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHP;
    private int _hp;

    public UnityEvent<float> UpdateHealth;
    
    private void Awake()
    {
        _hp = _maxHP;
    }

    public void ChangeHealth(int value)
    {
        _hp = Mathf.Clamp(_hp + value, 0, _maxHP);
        UpdateHealth?.Invoke(_hp / (float)_maxHP); // 이건 UI에 값을 갱신 하는거 
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z) * (Time.deltaTime * _speed);
        
        transform.Translate(movement);
        
        if (Input.GetButtonDown("Jump"))
            ChangeHealth(-10);
    }
}
