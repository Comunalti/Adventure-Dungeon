using System;
using Managers;
using UnityEngine;
using MovementCommands;

public class Dash : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    private float direcao;
    private bool estaNoChao;
    private bool olhandoDireita = true;
    

    private float dashAtual;
    private bool canDash;
    private bool isDashing;
    public float duracaoDash;
    public float dashSpeed;
    

   
    void Update()
    {
        DoDash();
    }

    void DoDash()
    {
        if (Input.GetKey(KeyCode.E) && estaNoChao && canDash)
        {
            if (dashAtual <= 0)
            {
                StopDash();
            }
            else
            {
                isDashing = true;
                dashAtual -= Time.deltaTime;

                if (olhandoDireita)
                    _rigidbody2D.velocity = Vector2.right * dashSpeed;
                else
                    _rigidbody2D.velocity = Vector2.left * dashSpeed;
            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isDashing = false;
            canDash = true;
            dashAtual = duracaoDash;
        }
    }

    private void StopDash()
    {
        _rigidbody2D.velocity = Vector2.zero;
        dashAtual = duracaoDash;
        isDashing = false;
        canDash = false;
    }
}
