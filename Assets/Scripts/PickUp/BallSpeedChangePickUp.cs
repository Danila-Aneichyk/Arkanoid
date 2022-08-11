using UnityEngine;

public class BallSpeedChangePickUp : PickUpBase
{
    #region Variables

    [Header(nameof(BallSpeedChangePickUp))]
    [SerializeField] private float _speedMultiplier; 

    #endregion
    #region Private methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSpeed(_speedMultiplier); 
    }

    #endregion
}
