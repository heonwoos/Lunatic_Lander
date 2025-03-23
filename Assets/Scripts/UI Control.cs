using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider thrustGauge;
    public Slider inclinometer;
    public Slider fuelGauge;

    public LunarLander lunarLander;
    void Start()
    {
        
    }

    void Update()
    {
        thrustGauge.value = lunarLander.GetThrust() / lunarLander.maxThrust * 100;
        inclinometer.value = lunarLander.GetInclination();
        fuelGauge.value = lunarLander.GetFuel() / lunarLander.maxFuel * 100;
    }
}
