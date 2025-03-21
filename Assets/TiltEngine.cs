using UnityEngine;

public class TiltEngine : MonoBehaviour
{
    public Vector2 rotationCenter;
    public float engineLength;
    private float engineLengthHalf;

    private void Start()
    {
        engineLengthHalf = engineLength / 2;
    }
    public void SetEngineAngle(float angle)
    {
        transform.SetLocalPositionAndRotation(
            new Vector2(
                rotationCenter.x - engineLengthHalf * Mathf.Sin(angle),
                rotationCenter.y - engineLengthHalf * Mathf.Cos(angle)
                ),

            Quaternion.Euler(new Vector3(0f, 0f, -angle * Mathf.Rad2Deg))
        );
    }
}