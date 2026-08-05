using System.Xml;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Distancia")]
    [SerializeField] private TextMeshProUGUI distanceText;
    private float distance = 0f;

    [Header("State Machines")]
    public StateMachine StateMachine { get; private set; }

    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    //public CrouchState CrouchState { get; private set; }
    //public DeadState DeadState { get; private set; }

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 10f;

    private void Awake()
    {

        StateMachine = new StateMachine();
        RunState = new RunState(this);
        JumpState = new JumpState(this);
        //CrouchState = new PlayerCrouchState(this);
        //DeadState = new PlayerDeadState(this);
    }

    void Start()
    {
        StateMachine.Initialize(RunState);   
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime;
        distanceText.text = "Distancia:" + Mathf.FloorToInt(distance) + "[m]";
        StateMachine.CurrentState.UpdateState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState(JumpState);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            // Si estábamos saltando y tocamos suelo, volvemos a Correr
            if (StateMachine.CurrentState == JumpState)
            {
                StateMachine.ChangeState(RunState);
            }
        }
    }
}
