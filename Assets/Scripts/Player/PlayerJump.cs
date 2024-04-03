using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody _rb = null;
    private bool _jumpFg = false;
    [SerializeField]
    private float _jumpForce = 2f;

    private void Start()
    {
        _rb = PlayerInfo.Instance.g_rb;
    }

    private void FixedUpdate()
    {
        jump();
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        _jumpFg |= context.performed;
    } 

    private void jump()
    {
        if (!_jumpFg) { return; }
        //Debug.Log($"ジャンプ{_jumpFg}着地{PlayerInfo.Instance.g_isGround}");
        if (PlayerInfo.Instance.g_isGround)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
        _jumpFg = false;
    }
}
