using Unity.VisualScripting;
using UnityEngine;

public class JumpingState : MonoBehaviour, IHeroineState
{
    Heroine _heroine;
    public void Enter(Heroine heroine)
    {
        _heroine = heroine;

        Debug.Log("Start Jumping");
        _heroine.rb.linearVelocity += new Vector3(0, 0.1f, 0);
        _heroine.rb.AddForce(Vector3.up * _heroine.jumpForce, ForceMode.VelocityChange);
    }

    private void Update()
    {
        //if the state is active and ready
        if (_heroine == null)
            return;
        if (Input.GetKeyDown(KeyCode.S))
        {
           _heroine.Transition(gameObject.AddComponent<DivingState>());
            Destroy(this);
        }
        //check if the player is grounded
        if (Physics.Raycast(transform.position, Vector3.down, _heroine.jumpCheckHeight, _heroine.groundMask) && _heroine.rb.linearVelocity.y <= 0)
        {
            Debug.Log("Grounded");
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _heroine.Transition(gameObject.AddComponent<WalkingState>());
            }
            else if (Input.GetKeyDown(KeyCode.Space))
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
}
