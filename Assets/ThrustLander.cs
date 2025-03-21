using UnityEngine;

public class ThrustLander : MonoBehaviour
{
    public float maxThrust;
    public float thrustChange;
    public float engineAngleMax;
    public float inertialMoment;
    private float thrust;
    private float engineAngle;
    private new Rigidbody2D rigidbody2D; // 이 문법은 무슨 뜻일까?
    public GameObject thrustEngine;
    private TiltEngine tiltEngine;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        tiltEngine = thrustEngine.GetComponent<TiltEngine>();
    }

    void FixedUpdate()
    {
        // 인풋 받기
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = - Input.GetAxis("Horizontal");

        // 추력 변화
        thrust += thrustChange * verticalAxis;


        thrust = Mathf.Clamp(thrust, 0f, maxThrust);

        // 추력 방향
        engineAngle = engineAngleMax * horizontalAxis;

        // 힘과 토크 주기
        rigidbody2D.AddRelativeForce(new Vector2(0, thrust * Mathf.Cos(engineAngle)));
        rigidbody2D.AddTorque(thrust * Mathf.Sin(engineAngle) / inertialMoment);

        // 엔진 움직이기
        tiltEngine.SetEngineAngle(engineAngle);
    }
}
