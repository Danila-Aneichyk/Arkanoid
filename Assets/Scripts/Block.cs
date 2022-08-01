using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _blockScore;
    [SerializeField] private int _hp;
    [Header("Sprites")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        _hp--;
        SetSprite();
        if (_hp<=0)
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Public methods

    #endregion


    #region Private methods

    private void SetSprite()
    {
        _spriteRenderer.sprite = _sprites[0];
    }

    #endregion
}