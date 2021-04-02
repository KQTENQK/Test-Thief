using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;

    private float _distanceToCheckGround = 1f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public bool IsWalking { get; private set; }
    public bool IsOnGround { get; private set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsOnGround = Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheckGround, _ground);
        _direction = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (_direction.x != 0)
        {
            IsWalking = true;
            transform.Translate(_direction.x * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }
    }
}
