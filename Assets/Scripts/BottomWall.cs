using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        DecrementHp();
    }

    #endregion


    #region Private Methods

    private void DecrementHp()
    {
        GameManager.Instance.DecrementHp();
    }

    #endregion
}