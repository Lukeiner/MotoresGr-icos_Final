using UnityEngine;

public class RunState : IState
{
    private PlayerController player;

    public RunState (PlayerController player)
    {
        this.player = player;
    }
    public void Enter ()
    {
        player.gameObject.layer = LayerMask.NameToLayer("JugadorCorriendo");
        player.PlayerAnimator.SetBool("isJumping", false);
        Debug.Log("Entrando al estado:Correr");
    }
    public void UpdateState ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.StateMachine.ChangeState(player.JumpState);
        }
        // Transición a Agacharse
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.StateMachine.ChangeState(player.CrouchState);
        }
    }
    public void Exit ()
    {
        Debug.Log("Saliendo de: Correr");
    }
}
