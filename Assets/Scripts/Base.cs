using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int stage;
    private float fuelNeeded;
    public LunarLander lunarLander;

    public void setStage(int num) {
        stage = num;
    }
    public void SetFuelNeeded(float fuelLevel) {
        fuelNeeded = fuelLevel;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Lunar Lander" && lunarLander.score < stage) {
            lunarLander.score = stage;
            lunarLander.SetFuel(fuelNeeded);
        }
    }
}
