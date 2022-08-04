using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _healthPoints;
    [SerializeField] public int NumOfHearts;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite FullHeart;
    [SerializeField] public Sprite EmptyHeart;

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
            hearts[i].sprite = i < Mathf.RoundToInt(_healthPoints) ? FullHeart : EmptyHeart;

            hearts[i].enabled = i < NumOfHearts;

            if (_healthPoints > 0)
                continue;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //GameManager.Instance.IsStarted = true; 
        }
    }


    #region Private Methods

    private void CountHp()
    {
        _healthPoints--;
    }

    #endregion

    #endregion
}