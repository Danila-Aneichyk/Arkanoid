using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    private bool _isStarted;
    [SerializeField] private Ball _ball;

    #endregion


    #region Unity lifecycle

    void Update()
    {
        if (_isStarted)
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
        _isStarted = true;
        _ball.StartMove();
    }

    #endregion
}