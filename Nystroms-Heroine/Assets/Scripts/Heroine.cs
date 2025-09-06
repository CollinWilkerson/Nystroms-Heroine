using Unity.VisualScripting;
using UnityEngine;

public class Heroine : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    public LayerMask groundMask;
    public float clampCutoff = 0.1f;
    public float clampSpeed = 0.5f;
    public float jumpCheckHeight = 1.0f;
    public float jumpForce = 10.0f;
    public float walkSpeed = 1.0f;
    public float runSpeed = 2.0f;
    public float diveSpeed = 5f;
    public IHeroineState currentState;

    public void Transition(IHeroineState state)
    {
        currentState = state;
        state.Enter(this);
    }

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("NO RIGIDBODY ATTACHED TO " + gameObject.name);
        }

        currentState = gameObject.AddComponent<StandingState>() as IHeroineState;

        Transition(currentState);
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * jumpCheckHeight, Color.red);
    }

}
