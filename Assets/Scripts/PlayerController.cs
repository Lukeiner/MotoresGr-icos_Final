using System;
using System.Xml;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("State Machines")]
    public StateMachine StateMachine { get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public CrouchState CrouchState { get; private set; }
    public DeadState DeadState { get; private set; }

    [Header("Ajustes de Agachado")]
    [SerializeField] private BoxCollider2D playerCollider; 
    [SerializeField] private Transform spriteTransform;

    private Vector3 originalSpriteScale;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 10f;

    public static event Action OnPlayerDied;

    [Header("Shader de Muerte")]
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private float dissolveDuration = 1f;

    [SerializeField] private Animator animator;
    public Animator PlayerAnimator => animator;
    [SerializeField] AudioSource saltito;

    private void Awake()
    {
        StateMachine = new StateMachine();
        RunState = new RunState(this);
        JumpState = new JumpState(this);
        CrouchState = new CrouchState(this);
        DeadState = new DeadState(this);

        if (spriteTransform != null) originalSpriteScale = spriteTransform.localScale;
        if (playerCollider != null)
        {
            originalColliderSize = playerCollider.size;
            originalColliderOffset = playerCollider.offset;
        }
    }
    void Start()
    {
        StateMachine.Initialize(RunState);   
    }
    void Update()
    {
        StateMachine.CurrentState.UpdateState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltito.Play();
            StateMachine.ChangeState(JumpState);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            if (StateMachine.CurrentState == JumpState)
            {
                StateMachine.ChangeState(RunState);
            }   
        }
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Die();
        }
    }
    public void TriggerDeathEvent()
    {
        OnPlayerDied?.Invoke();
    }
    public void Die()
    {
        if (StateMachine.CurrentState != DeadState)
        {
            StateMachine.ChangeState(DeadState);
        }
    }

    public void ToggleCrouch(bool isCrouching)
    {
        if (isCrouching)
        {
            
            spriteTransform.localScale = new Vector3(originalSpriteScale.x, originalSpriteScale.y * 0.7f, originalSpriteScale.z);
            playerCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y * 0.7f);
            playerCollider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y * 0.7f);
        }
        else
        {
            spriteTransform.localScale = originalSpriteScale;
            playerCollider.size = originalColliderSize;
            playerCollider.offset = originalColliderOffset;
        }
    }
    public void StartDissolveEffect()
    {
        StartCoroutine(DissolveRoutine());
    }
    private System.Collections.IEnumerator DissolveRoutine()
    {
        Material mat = playerSpriteRenderer.material;
        float elapsedTime = 0f;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float dissolveValue = Mathf.Lerp(0f, 1f, elapsedTime / dissolveDuration);

            mat.SetFloat("_DissolveAmount", dissolveValue);

            yield return null;
        }
        mat.SetFloat("_DissolveAmount", 1f);
    }


}
