public class GameStateController
{
    public static GameStateController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameStateController();

            }

            return instance;
        }
    }

    private static GameStateController instance;

    private IGameState mState;
    private bool mIsBegin = false;

    private GameStateController() {}

    public void SetState(IGameState state)
    {
        mIsBegin = false;

        if (mState != null)
        {
            mState.StateEnd();
        }

        mState = state;
    }

    public void StateUpdate()
    {
        if (mState != null)
        {
            if (mIsBegin == false)
            {
                mState.StateBegin();
                mIsBegin = true;
            }

            mState.StateUpdate();
        }
    }

    public IGameState GetCurrentState()
    {
        return mState;
    }
}
