using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator player;
    private void Start()
    {
        player = GetComponentInChildren<Animator>();
    }
    public void Walking(float move)
    {
        player.SetFloat("IsWalking", Mathf.Abs(move));
    }
    public void Jumping(bool jump)
    {
        player.SetBool("IsJumping", jump);
    }
}
