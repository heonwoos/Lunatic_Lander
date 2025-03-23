using UnityEngine;

public class Base : MonoBehaviour
{
    private int stage;
    public LunarLander lunarlander;

    public void setStage(int num) {
        stage = num;
    }

    float computeFuelAmount() {
        // 대충 현재 base 좌표와 다음 base좌표 사이 거리를 측정하여 비례해서 연료 주기

        return 100f;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Lunar Lander" && lunarlander.score < stage) {
            lunarlander.score = stage;
        }
        lunarlander.SetFuel(computeFuelAmount());
    }
}
