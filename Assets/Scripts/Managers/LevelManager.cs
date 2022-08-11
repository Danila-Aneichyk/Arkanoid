using System;

public class LevelManager : SingletonMonoBehavior<LevelManager>
{
    #region Variables

    private bool _isWin;
    private int _blockCount;

    #endregion


    #region Events

    public event Action OnAllBlocksDestroyed;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        Block.OnCreated += BlockCreated; 
        Block.OnDestroyed += BlockDestroyed;
    }
    

    private void Start()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        _blockCount = blocks.Length;
    }

    private void OnDestroy()
    {
        Block.OnDestroyed -= BlockDestroyed;
        Block.OnCreated -= BlockCreated; 
    }

    #endregion


    #region Private metods

    private void BlockCreated(Block obj)
    {
        _blockCount++; 
    }
    
    private void BlockDestroyed(Block block)
    {
        
        _blockCount--;

        if (_blockCount == 0)
        {
            OnAllBlocksDestroyed?.Invoke();
        }
    }

    #endregion
}