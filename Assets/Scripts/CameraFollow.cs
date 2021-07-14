using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float followSpeed = 0.5f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(15f, 0f, 0f);
    }

    private void LateUpdate()
    {
        if (cameraTarget != null)
        {
            Vector3 newPosition = cameraTarget.position;
            newPosition = new Vector3(newPosition.x, newPosition.y + 2f, newPosition.z - 4);
            transform.position = newPosition;
        }
    }
}
