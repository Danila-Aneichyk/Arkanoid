using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] public Pad Pad; 
    [SerializeField] private int _healthPoints;
    [SerializeField] public int NumOfHearts;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite FullHeart;
    [SerializeField] public Sprite EmptyHeart;

    #endregion


    #region Public Methods

    public void CountHp()
    {
        _healthPoints--;
    }

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        CountHp();
    }

    private void FixedUpdate()
    {
        if (_healthPoints > NumOfHearts)
        {
            _healthPoints = NumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(_healthPoints))
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (_healthPoints <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    #endregion
}