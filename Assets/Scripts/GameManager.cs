using System;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    #region Variables

    [SerializeField] private int _maxHp;

    #endregion


    #region Properties

    public int CurrentHp { get; private set; }

    #endregion


    #region Events

    public event Action OnGameOver;

    public event Action OnGameWon;

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

    #endregion


    #region Public methods

    public void DecrementHp()
    {
        CurrentHp--;
        FindObjectOfType<Ball>().ToDefaultState();

        if (CurrentHp == 0)
        {
            OnGameOver?.Invoke();
        }
    }

    #endregion


    #region Private methods

    private void PerformWin()
    {
        OnGameWon?.Invoke();
        Debug.Log("WIN!!!");
    }

    #endregion
}