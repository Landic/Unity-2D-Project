using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        minX = -screenBounds.x;
        maxX = screenBounds.x;
        minY = -screenBounds.y;
        maxY = screenBounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(Vector2.up * 5);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * 5);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * 5);
        }

        Vector2 position = rb2d.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        rb2d.position = position;

        if (Input.GetKey(KeyCode.Escape))
        {
            ResetForces();
        }
    }

    void ResetForces()
    {
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
    }
}
