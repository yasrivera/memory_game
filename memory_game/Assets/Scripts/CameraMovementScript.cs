using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.right * (5f * Time.deltaTime));
    }
}
