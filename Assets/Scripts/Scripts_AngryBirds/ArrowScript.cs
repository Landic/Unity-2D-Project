using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]  //разрешает установить объект из сцены
    private Transform rotAnchor;
    private float minRotationAngle = -50.0f;
    private float maxRotationAngle = 70.0f;


    void Update()
    {
        float dy = Input.GetAxis("Vertical");
        float curRotAngle = this.transform.eulerAngles.z;
        if(curRotAngle > 180)
        {
            curRotAngle -= 360;
        }
        if (curRotAngle + dy > minRotationAngle && curRotAngle + dy< maxRotationAngle)
        {
            this.transform.RotateAround(rotAnchor.position, Vector3.forward, dy);
        }
        //float rotAngle = Mathf.Clamp(curRotAngle + dy, minRotationAngle, maxRotationAngle);
        

    }
}
