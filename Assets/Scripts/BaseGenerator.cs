using UnityEditor;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    public MoonGenerator moonGenerator;
    public GameObject basePrefab;
    public LunarLander lunarLanderInstance;

    void Start()
    {
        Vector2[] baseCoordinates = moonGenerator.GetBaseCoordinates();
        
        for (int i = 0; i < baseCoordinates.Length; i++) {
            GameObject newBase = Instantiate(
                original: basePrefab,
                position: baseCoordinates[i],
                rotation: Quaternion.Euler(0, 0, 0),
                parent: transform);
            Base baseScript = newBase.GetComponent<Base>();
            baseScript.setStage(i);
            baseScript.lunarLander = lunarLanderInstance;
        }
    }

}
