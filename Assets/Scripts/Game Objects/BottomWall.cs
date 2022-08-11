using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            DecrementHp();
        }
        else
        {
            Destroy(col.gameObject);
        }

            
    }

    #endregion


    #region Private Methods

    private void DecrementHp()
    {
        GameManager.Instance.LoseLife();
    }

    #endregion
}