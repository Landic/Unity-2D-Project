using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private TMPro.TextMeshProUGUI title_tmp;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI goButtonTMP;

    void Start()
    {
        this.ShowModal(content.activeInHierarchy);
        GameState.modalScriptInstance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.ShowModal(!content.activeInHierarchy);
        }
    }

    public void ShowModal(bool isShown, string title = null, string message = null, string goButton = null)
    {
        if (isShown)
        {
            if (title == null)
            {
                title = "ПАУЗА";
            }
            if (message == null)
            {
                message = "Для продовження гри натисніть кнопку 'ПРОДОВЖИТИ' або клавішу ESC";
            }
            if (goButton == null)
            {
                goButton = "ПРОДОВЖИТИ";
            }
            if(title == "ПАУЗА")
            {
                retryButton.SetActive(true);
            }
            else
            {
                retryButton.SetActive(false);
            }
            Time.timeScale = 0f;
            title_tmp.text = title;
            messageTMP.text = message;
            goButtonTMP.text = goButton;
            content.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            content.SetActive(false);
        }
    }

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGoButtonClick()
    {
        if (GameState.isLevelCompleted)
        {
            if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            } 
        }
        else
        {
            if (GameState.isLevelFailed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            ShowModal(false);
        }
    }

    public void OnExitButtonClick()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
