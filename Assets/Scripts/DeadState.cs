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
            rb.linearVelocity = Vector2.zero;
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
        player.StartDissolveEffect();
        yield return new WaitForSeconds(1f);
        player.TriggerDeathEvent();
    }


}
