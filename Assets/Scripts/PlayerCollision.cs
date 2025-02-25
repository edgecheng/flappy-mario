using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        GameStateController.Instance.SetState(new GamePauseState());
    }
}
