using System;
using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Pad))
            return;

        ApplyEffect(col);
        Destroy(gameObject);
    }


    #region Protected regions

    protected abstract void ApplyEffect(Collision2D col);

    #endregion

    #endregion
}