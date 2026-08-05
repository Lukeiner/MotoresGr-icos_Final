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

        // 1. Cambiamos la capa del jugador a "JugadorSaltando" (según consigna)
        player.gameObject.layer = LayerMask.NameToLayer("JugadorSaltando");

        //player.ApplyJumpForce();

        // 3. Activar animación de salto (si ya tenés el Animator configurado)
        // player.Animator.SetTrigger("Jump");
    }

    public void UpdateState()
    {
        // En el estado de salto no escuchamos teclas para cambiar de estado, 
        // simplemente esperamos a que la física nos haga tocar el suelo de nuevo.
    }

    public void Exit()
    {
        Debug.Log("Saliendo de: JUMP STATE");
    }
}
