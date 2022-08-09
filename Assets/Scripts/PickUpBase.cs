using System;
using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        ApplyEffect(col);
    }


    #region Protected regions

    protected abstract void ApplyEffect(Collision2D col);

    #endregion

    #endregion
}