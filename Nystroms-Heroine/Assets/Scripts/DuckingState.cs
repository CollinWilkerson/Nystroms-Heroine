using UnityEngine;

public class DuckingState : MonoBehaviour, IHeroineState
{
    Heroine _heroine;
    public void Enter(Heroine heroine)
    {
        _heroine = heroine;

        Debug.Log("started ducking");
        transform.localScale = new Vector3(1, 0.5f, 1);
    }

    private void Update()
    {
        if (!_heroine)
            return;
        
        if (!Input.GetKey(KeyCode.S))
        {
            transform.localScale = Vector3.one;
            _heroine.Transition(gameObject.AddComponent<StandingState>());
            Destroy(this);
        }
    }
}
