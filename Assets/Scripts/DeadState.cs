using UnityEngine;

public class DeadState : IState
{
    private PlayerController player;

    public DeadState (PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("Entrando al estado: MUERTE");

        // 1. Cambiamos la capa si es necesario o desactivamos futuras colisiones
        player.gameObject.layer = LayerMask.NameToLayer("Default");

        // 2. Avisamos a la UI y al juego que el jugador murió mediante el evento (Observer)
        player.TriggerDeathEvent();
    
        
    }
    public void UpdateState ()
    {

    }

    public void Exit()
    {

    }
}
