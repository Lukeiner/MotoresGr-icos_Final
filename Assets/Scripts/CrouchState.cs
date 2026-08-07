using UnityEngine;

public class CrouchState : IState
{
    private PlayerController player;

    public CrouchState (PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        int crouchLayer = LayerMask.NameToLayer("JugadorAgachado");
        if (crouchLayer != -1)
        {
            player.gameObject.layer = crouchLayer;
        }
        player.ToggleCrouch(true);
    }
    public void UpdateState()
    {
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            player.StateMachine.ChangeState(player.RunState);
        }
    }
    public void Exit()
    {
        player.ToggleCrouch(false);
    }
}
