using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject target;
    public Vector2 cameraOffset;
    public float cameraHeightMin;
    public float cameraHeightMax;


    void FixedUpdate()
    {
        transform.position = new Vector3(
            target.transform.position.x + cameraOffset.x,
            Mathf.Clamp(target.transform.position.y, cameraHeightMin, cameraHeightMax) + cameraOffset.y, -10);
    }
}
