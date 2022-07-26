using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _healthPoints = 3;

    #endregion


    #region Public Methods

    public void CountHp()
    {
        _healthPoints--;
        SceneLoader.ReloadScene();

        if (_healthPoints <= 0)
            SceneLoader.ReloadScene();
    }

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        CountHp();
    }

    #endregion
}