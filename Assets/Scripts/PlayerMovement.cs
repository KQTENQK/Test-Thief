using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsWalking { get; private set; }
    public bool IsOnGround { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;

    private float _distanceToCheckGround = 1f;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsOnGround = Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheckGround, _ground);

        if (Input.GetKey(KeyCode.A))
        {
            IsWalking = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            IsWalking = true;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }
    }
}
