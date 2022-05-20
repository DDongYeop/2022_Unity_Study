using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionParticle;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction, float power)
    {
        _rigidbody2D.AddForce(direction * power);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ParticleSystem ps = Instantiate(_explosionParticle, transform.position, Quaternion.identity) as ParticleSystem;
        ps.Play();
        Destroy(ps, 2f);
        Destroy(gameObject);
    }
}
