using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float minForce = 500f;
    [SerializeField]
    private float maxForce = 2000f;

    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float forceAmplitude = minForce + (maxForce - minForce) * IndicatorScript.forceFactor;
            rb2d.AddForce(arrow.right * forceAmplitude);
        }
            
    }
}