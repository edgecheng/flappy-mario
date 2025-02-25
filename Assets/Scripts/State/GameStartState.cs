using UnityEngine;

public class GameStartState : IGameState
{
    public GameStartState() : base()
    {
        StateName = "GameStart";
    }

    public override void StateBegin()
    {
        GameObject[] spawns = UnityTool.FindGameObjectsWithTag("Respawn");

        foreach (GameObject obj in spawns)
        {
            PipeFactory.Instance.ReturnToPool(obj);
        }

        PlayerController.Instance.Start();
    }
}
