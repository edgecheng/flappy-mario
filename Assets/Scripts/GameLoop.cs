using UnityEngine;

public class GameLoop : MonoBehaviour
{
    void Start()
    {
        Main.Instance.Initialize();
        GameStateController.Instance.SetState(new GamePauseState());
    }

    void Update()
    {
        GameStateController.Instance.StateUpdate();
        PlayerController.Instance.Update();
    }
}
