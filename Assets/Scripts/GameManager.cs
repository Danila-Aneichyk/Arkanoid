using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    
    #region Variables

    [SerializeField] private Ball _ball;

    #endregion


    #region Properties

    public bool IsStarted { get; set; }

    #endregion


    #region Unity lifecycle

    void Update()
    {
        if (IsStarted)
        {
            return;
        }

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            _startBall();
        }
    }

    #endregion


    #region Private methods

    private void _startBall()
    {
        Debug.Log("Start Ball");
        IsStarted = true;
        _ball.StartMove();
    }

    #endregion
}