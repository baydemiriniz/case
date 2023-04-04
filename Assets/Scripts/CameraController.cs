using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float camOffset;

    private void LateUpdate()
    {
       CameraFollow();
    }

    private void CameraFollow()
    {
        var position = transform.position;
        position = new Vector3(
            player.transform.position.x + camOffset, position.y, position.z);
        transform.position = position;
    }
}