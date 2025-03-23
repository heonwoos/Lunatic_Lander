using UnityEngine;

public class LunarLander : MonoBehaviour
{
    public float maxThrust = 2f;
    public float thrustChange = 0.2f;
    public float engineAngleMax = 0.5f;
    public float inertialMoment = 5f;
    private float thrust = 0f;
    private float engineAngle = 0f;
    public float maxFuel = 100f;
    private float fuel = 100f;
    public int score = 0;
    private new Rigidbody2D rigidbody2D; // 이 문법은 무슨 뜻일까?
    public GameObject thrustEngine;
    private TiltEngine tiltEngine;
    
    public float GetThrust()
    {
        return thrust;
    }
    public float GetInclination()
    {
        float rawInclination = transform.rotation.eulerAngles.z;
        if (rawInclination > 180)
            return rawInclination - 360;
        else return rawInclination;
    }
    
    public float GetFuel()
    {
        return fuel;
    }

    public void SetFuel(float fuelLevel) {
        maxFuel = fuelLevel;
        fuel = maxFuel;
    }

    public void Die() {
        Destroy(this);
    }

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
