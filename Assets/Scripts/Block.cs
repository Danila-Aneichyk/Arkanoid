using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _blockScore;
    [SerializeField] private int _hp;
    [Header("Sprites")]
    [SerializeField]
    protected SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;

    #endregion


    #region Events

    public static event Action<Block> OnCreated;  

    public static event Action<Block> OnDestroyed;
    
    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        BlockDestroy();
    }

    private void OnDestroy()
    {   
        OnDestroyed?.Invoke(this);
    }
    

    #endregion


    #region Public methods

    #endregion


    #region Private methods

    private void SetSprite()
    {
        _spriteRenderer.sprite = _sprites[0];
    }

    protected virtual void BlockDestroy()
    {
        _hp--;
        SetSprite();
        if (_hp <= 0)
        {
            Destroy(gameObject);
            ScoreManager.Instance.ChangeScore(_blockScore);
        }
    }
    

    #endregion
}