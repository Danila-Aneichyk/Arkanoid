using UnityEditor;
using UnityEngine;

public class PauseManager : SingletonMonoBehavior<PauseManager>
{
    #region Variables

    [SerializeField] public GameObject PauseView;

    #endregion


    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    #endregion


    #region Private methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        PauseView.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion


    #region Public methods

    public void Resume()
    {
        PauseView.SetActive(false);
        IsPaused = !IsPaused;
        Time.timeScale = 1;
    }

    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    #endregion
}