using UnityEngine;

public class RuningState : MonoBehaviour, IHeroineState
{

    private Heroine _heroine;
    private bool left;

    public void Enter(Heroine heroine)
    {
        _heroine = heroine;

        Debug.Log("started running");
    }

    private void Update()
    {
        if (_heroine == null)
            return;
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            _heroine.Transition(gameObject.AddComponent<WalkingState>());
            Destroy(this);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _heroine.Transition(gameObject.AddComponent<JumpingState>());
            Destroy(this);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _heroine.Transition(gameObject.AddComponent<DuckingState>());
            Destroy(this);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            left = false;
        }
        else
        {
            _heroine.Transition(gameObject.AddComponent<StandingState>());
            Destroy(this);
        }

    }

    private void FixedUpdate()
    {
        if (left)
        {
            _heroine.rb.AddForce(Vector3.left * _heroine.runSpeed, ForceMode.VelocityChange);
        }
        else
        {
            _heroine.rb.AddForce(Vector3.right * _heroine.runSpeed, ForceMode.VelocityChange);
        }
    }
}
