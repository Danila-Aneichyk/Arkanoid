using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _blockScore;
    [SerializeField] private int _hp;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;
    [Header("PickUp")]
    [SerializeField] private GameObject _pickUpPrefab;
    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;

    #endregion


    #region Events

    public static event Action<Block> OnCreated;

    public static event Action<Block> OnDestroyed;

    #endregion


    #region Unity lifecycle

    protected virtual void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SpawnPickUp();
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

    private void SpawnPickUp()
    {
        if (_pickUpPrefab == null)
            return;

        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChance)
        {
            Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
        }
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