using UnityEngine;

public class ScoreChangedPickUp : PickUpBase
{
    [Header(nameof(ScoreChangedPickUp))]
    [SerializeField] private int _score;

    protected override void ApplyEffect(Collision2D col)
    {
        ScoreManager.Instance.ChangeScore(_score);
    }
}