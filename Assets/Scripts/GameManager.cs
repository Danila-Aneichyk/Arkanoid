using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    #region Variables

    [SerializeField] private Ball _ball;
    [SerializeField] private int _maxHp;

    #endregion


    #region Properties

    private bool IsStarted { get; set; }
    public int CurrentHp { get; private set; }

    #endregion


    #region Unity lifecycle

    public void Start()
    {
        CurrentHp = _maxHp;
    }

    void Update()
    {
        if (IsStarted)
        {
            return;
        }

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        Debug.Log("Start Ball");
        IsStarted = true;
        _ball.StartMove();
    }

    #endregion


    public void DecrementHp()
    {
        CurrentHp--;

        if (CurrentHp == 0)
        {
            //TODO: GameOver
        }
        else
        {
            IsStarted = false;
        }
    }
}