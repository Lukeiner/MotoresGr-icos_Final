using UnityEngine;

public class JumpState : IState
{
    private PlayerController player;

    public JumpState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("Entrando a: JUMP STATE");
        player.gameObject.layer = LayerMask.NameToLayer("JugadorSaltando");
        player.PlayerAnimator.SetBool("isJumping", true);

    }
    public void UpdateState()
    {
    
    }
    public void Exit()
    {
        Debug.Log("Saliendo de: JUMP STATE");
        player.PlayerAnimator.SetBool("isJumping", false);
    }
}
