using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region Variables

    private bool _isPaused;
    [SerializeField] public Button ExitButton;
    [SerializeField] public Button ResumeButton;
    [SerializeField] public GameObject PauseView;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

            if (_isPaused)
            {
                TogglePause();
            }
            else
            {
                Resume();
            }
    }

    #endregion


    #region Private methods

    private void TogglePause()
    {
        PauseView.SetActive(true);
        _isPaused = !_isPaused;
        Time.timeScale = 0;
    }
    
    #endregion


    #region Public methods

    public void Resume()
    {
        PauseView.SetActive(false);
        _isPaused = !_isPaused;
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