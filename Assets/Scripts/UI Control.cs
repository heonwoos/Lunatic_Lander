using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider thrustGauge;
    public Slider speedometer;
    public Slider fuelGauge;
    public LunarLander lunarLander;
    void Update()
    {
        thrustGauge.value = lunarLander.GetThrust() / lunarLander.maxThrust * 100;
        speedometer.value = lunarLander.GetHorizontalVelocity();
        fuelGauge.value = lunarLander.GetFuel() / lunarLander.maxFuel * 100;
    }
}
