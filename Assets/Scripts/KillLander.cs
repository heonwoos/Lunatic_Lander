using Unity.VisualScripting;
using UnityEngine;

public class KillLander : MonoBehaviour
{
    public GameObject lunarLander;
    private LunarLander lunarLanderInstance;

    void Start() {
        lunarLanderInstance = lunarLander.GetComponent<LunarLander>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == lunarLander) {
            lunarLanderInstance.Die();
        }
    }
}
