using UnityEngine;
using UnityEngine.UI;

public class GamePauseState : IGameState
{
    private Button mStartButton;

    public GamePauseState() : base()
    {
        StateName = "GamePause";
        mStartButton = UITool.GetUIComponent<Button>("StartButton");
    }

    public override void StateBegin()
    {
        Time.timeScale = 0;
        mStartButton.gameObject.SetActive(true);
        mStartButton.onClick.AddListener(() => OnStartButtonClick());
    }

    public override void StateEnd()
    {
        Time.timeScale = 1;
        mStartButton.onClick.RemoveAllListeners();
        mStartButton.gameObject.SetActive(false);
    }

    private void OnStartButtonClick()
    {
        GameStateController.Instance.SetState(new GameStartState());
    }
}
