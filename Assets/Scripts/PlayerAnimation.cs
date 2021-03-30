using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_movement.IsWalking && Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("IsWalking", true);
            _spriteRenderer.flipX = false;
        }

        else if (_movement.IsWalking && Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("IsWalking", true);
            _spriteRenderer.flipX = true;
        }

        else
        {
            _animator.SetBool("IsWalking", false);
        }

        if (_movement.IsOnGround && Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }
    }
}
