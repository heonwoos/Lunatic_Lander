using UnityEngine;

public class EngineParticle : MonoBehaviour
{
    private ParticleSystem.MainModule mainModule;
    public LunarLander lunarLander;
    private float lifetimeThrustRatio = 0.5f;
    void Start()
    {
        mainModule = GetComponent<ParticleSystem>().main;
    }

    void Update()
    {
        mainModule.startLifetime = lunarLander.GetThrust() * lifetimeThrustRatio;
    }
}
