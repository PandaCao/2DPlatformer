using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _doorDestroyed;
    private bool _isPaused;
    public int appleCount;
    public TMP_Text appleText;
    public GameObject door;
    public GameObject pauseMenu;
    public GameObject finishPanel;

    private void Start()
    {
        appleCount = 0;
    }
    
    private void Update()
    {
        if (appleText)
        {
            appleText.text = ": " + appleCount;
        }

        if (appleCount == 4 && !_doorDestroyed)
        {
            _doorDestroyed = true;
            Destroy(door);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            if (_isPaused)
                Pause();
            else
                Resume();
        }
    }
    
    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SelectLevel(0);
    }
    
    public void SelectLevel(int level) {
        SceneManager.LoadSceneAsync(level);
    }
}
