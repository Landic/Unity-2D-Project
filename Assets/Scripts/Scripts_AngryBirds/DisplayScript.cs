using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private float levelTimeout = 15f; // seconds
    private TMPro.TextMeshProUGUI clockTMP;
    private float gameTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clockTMP = GameObject.Find("ClockTMP").GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (clockTMP != null)
        {
            int hours = (int)(gameTime / 3600f);
            int minutes = (int)((gameTime % 3600f) / 60f);
            int seconds = (int)(gameTime % 60f);
            float milliseconds = (gameTime % 1f);

            clockTMP.text = string.Format("{0:00}:{1:00}:{2:00}.{3:0}",
                hours,
                minutes,
                seconds,
                (int)(milliseconds * 10));
        }
        if(gameTime >= levelTimeout)
        {
            GameState.isLevelFailed = true;
            GameState.Pause("вюя бхвепоюмн", null, "пнгонвюрх г онвюрйс");
        }
    }
}
