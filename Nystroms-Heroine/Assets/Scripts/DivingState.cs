using UnityEngine;

public class DivingState : MonoBehaviour, IHeroineState
{
    private Heroine _heroine;
    private bool dive;
    public void Enter(Heroine heroine)
    {
        _heroine = heroine;

        Debug.Log("started diving");
        dive = true;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, _heroine.jumpCheckHeight, _heroine.groundMask))
        {
            Debug.Log("Grounded");
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _heroine.Transition(gameObject.AddComponent<WalkingState>());
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                _heroine.Transition(gameObject.AddComponent<JumpingState>());
            }
            else
            {
                _heroine.Transition(gameObject.AddComponent<StandingState>());
            }
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        if (dive)
        {
            _heroine.rb.linearVelocity = Vector3.zero;
            _heroine.rb.AddForce(Vector3.down * _heroine.diveSpeed, ForceMode.VelocityChange);
            dive = false;
        }
            
    }
}
