using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int stage;
    public LunarLander lunarLander;

    void Start()
    {
    }
    public void setStage(int num) {
        stage = num;
    }

    float computeFuelAmount() {
        // 대충 현재 base 좌표와 다음 base좌표 사이 거리를 측정하여 비례해서 연료 주기

        return 100f;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Lunar Lander" && lunarLander.score < stage) {
            lunarLander.score = stage;
        }
        lunarLander.SetFuel(computeFuelAmount());
    }
}
