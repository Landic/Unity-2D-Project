using UnityEngine;
using UnityEngine.UI;

public class IndicatorScript : MonoBehaviour
{
    public static float forceFactor;
    [SerializeField]
    private Image indicatorFg;
    [SerializeField]
    private float sensitivity = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceFactor = indicatorFg.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        if(dx != 0)
        {
            dx *= sensitivity;
            if (0.1f <= indicatorFg.fillAmount + dx && indicatorFg.fillAmount + dx <= 1.0f)
            {
                forceFactor = indicatorFg.fillAmount += dx;
            }
        }
    }
}
