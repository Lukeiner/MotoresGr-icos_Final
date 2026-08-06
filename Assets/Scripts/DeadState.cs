using UnityEngine;
using System.Collections;

public class DeadState : IState
{
    private PlayerController player;


    public DeadState (PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        if (player.PlayerAnimator != null)
            player.PlayerAnimator.enabled = false;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 2. FRENAMOS TODA VELOCIDAD ACTUAL
            rb.linearVelocity = Vector2.zero;
            // 3. HACEMOS EL BODY 'STATIC' (no le afecta gravedad ni fuerzas)
            rb.bodyType = RigidbodyType2D.Static;
        }


        player.StartCoroutine(WaitAndDieRoutine());
    }
    public void UpdateState ()
    {

    }

    public void Exit()
    {

    }

    private IEnumerator WaitAndDieRoutine()
    {
        // Dispara la corrutina que mueve el _DissolveAmount de 0 a 1
        player.StartDissolveEffect();

        // Esperamos 1 segundo (o la duración que le diste al dissolve)
        yield return new WaitForSeconds(1f);

        // 3. RECIÉN ACÁ notificamos al GameManager/UI que el juego terminó
        player.TriggerDeathEvent();
    }


}
