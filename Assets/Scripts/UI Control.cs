using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider thrustGauge;
    public Slider inclinometer;
    public Slider fuelGauge;
    public TextMeshProUGUI scoreText;
    public LunarLander lunarLander;

    void Update()
    {
        thrustGauge.value = lunarLander.GetThrust() / lunarLander.maxThrust * 100;
        inclinometer.value = lunarLander.GetInclination();
        fuelGauge.value = lunarLander.GetFuel() / lunarLander.maxFuel * 100;
        scoreText.text = lunarLander.score.ToString(); // 굳이 Update에서 점수를 바꿔야 할까?
    }
}
