using UnityEngine;

public class StandingState : MonoBehaviour, IHeroineState
{
    private Heroine _heroine;
    public void Enter(Heroine heroine)
    {
        _heroine = heroine;

        Debug.Log("started standing");
    }

    private void Update()
    {
        if (_heroine == null)
            return;
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            _heroine.Transition(gameObject.AddComponent<WalkingState>() as IHeroineState);
            Destroy(this);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _heroine.Transition(gameObject.AddComponent<JumpingState>() as IHeroineState);
            Destroy(this);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _heroine.Transition(gameObject.AddComponent<DuckingState>() as IHeroineState);
            Destroy(this);
        }
    }
}
