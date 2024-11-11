using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI title_tmp;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;

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

    public void ShowModal(bool isShown, string title = null, string message = null)
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

            Time.timeScale = 0f;
            title_tmp.text = title;
            messageTMP.text = message;
            content.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            content.SetActive(false);
        }
    }

    public void OnGoButtonClick()
    {
        if (GameState.isLevelCompleted)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
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
