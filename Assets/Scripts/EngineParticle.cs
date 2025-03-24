using Unity.VisualScripting;
using UnityEngine;

public class EngineParticle : MonoBehaviour
{
    private ParticleSystem engineParticleSystem;
    public LunarLander lunarLander;
    private float lifetimeThrustRatio = 0.5f;
    void Start()
    {
        engineParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (engineParticleSystem != null){
            var main = engineParticleSystem.main;
            main.startLifetime = lunarLander.GetThrust() * lifetimeThrustRatio;
        } else {
            engineParticleSystem = GetComponent<ParticleSystem>();
        }
    }
}
