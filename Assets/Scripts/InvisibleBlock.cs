using UnityEngine;

public class InvisibleBlock : Block
{
    #region Variables

    private bool _isVisible;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        SetInvisibility(0f);
    }

    #endregion


    #region Protected methods

    protected override void BlockDestroy()
    {
        SetInvisibility(1f);
        
        if (_isVisible)
            base.BlockDestroy();

        _isVisible = true;
    }

    #endregion


    #region Private methods

    private void SetInvisibility(float alpha)
    {
        Color color = _spriteRenderer.color;
        color.a = alpha;
        _spriteRenderer.color = color;
    }

    #endregion
}
