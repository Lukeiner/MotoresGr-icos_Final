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
        Debug.Log("Entrando a: CROUCH STATE");

        // 1. Cambiamos la capa a 'JugadorAgachado' para la matriz de colisiones
        int crouchLayer = LayerMask.NameToLayer("JugadorAgachado");
        if (crouchLayer != -1)
        {
            player.gameObject.layer = crouchLayer;
        }

        // 2. Encogemos el personaje y su collider al 70%
        player.ToggleCrouch(true);
    }

    public void UpdateState()
    {
        // Al soltar la tecla de agacharse (ej. S o Flecha Abajo), volvemos a Correr
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            player.StateMachine.ChangeState(player.RunState);
        }
    }

    public void Exit()
    {
        Debug.Log("Saliendo de: CROUCH STATE");

        // Volvemos a la escala y collider normal
        player.ToggleCrouch(false);
    }
}
