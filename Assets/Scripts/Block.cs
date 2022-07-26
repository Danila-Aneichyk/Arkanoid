using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] public int _hp;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Sprites")]
    public Sprite[] _sprites;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        _hp--;
        SetSprite();
        if (_hp < 0)
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