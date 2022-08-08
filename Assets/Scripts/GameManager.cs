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

    protected override void Awake()
    {
        base.Awake();
        CurrentHp = _maxHp;
    }

    public void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerformWin;
    }

    private void Update()
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


    #region Public methods

    public void PerformWin()
    {
        Debug.Log("WIN!!!");
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