using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;
    [SerializeField] private Pad _pad;
    [SerializeField] private float _minSpeed = 1;  
    private bool _isStarted;
    private Vector3 _startPosition;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _startDirection);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _rb.velocity);
    }

    #endregion


    #region Public methods

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void ToDefaultState()
    {
        _isStarted = false;
        _rb.velocity = Vector2.zero;  
        transform.position = _startPosition;
    }

    public void MoveWithPad()
    {
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        transform.position = currentPosition;
    }

    public void ChangeSpeed(float _speedMultiplier)
    {
        float velocityMagnitude = _rb.velocity.magnitude;
        velocityMagnitude *= _speedMultiplier;

        if (velocityMagnitude < _minSpeed)
            velocityMagnitude = _minSpeed;

        _rb.velocity = _rb.velocity.normalized * velocityMagnitude; 
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        Debug.Log("Start Ball");
        _isStarted = true;
        StartMove();
    }

    #endregion
}