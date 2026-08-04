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
        Debug.Log("Entrando al estado:Correr");
    }

    public void UpdateState ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.StateMachine.ChangeState(player.JumpState);
        }

    }

    public void Exit ()
    {
        Debug.Log("Saliendo de: Correr");
    }
}
