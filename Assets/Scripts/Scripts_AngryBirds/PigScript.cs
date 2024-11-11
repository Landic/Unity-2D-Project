using UnityEngine;
using UnityEngine.SceneManagement;

public class PigScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PigDestroy"))
        {
            GameState.isLevelCompleted = true;
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                GameState.Pause("ÂÈÃĞÀØ", "Ãğà ïğîéäåíà", "ĞÎÇÏÎ×ÀÒÈ Ç ÏÎ×ÀÒÊÓ");
            }
            else
            {
                GameState.Pause("ÂÈÃĞÀØ", "Ğ³âåíü ïğîéäåíî", "ÍÀÑÒÓÏÍÈÉ Ğ²ÂÅÍÜ");
            }
        }
       
    }
}
