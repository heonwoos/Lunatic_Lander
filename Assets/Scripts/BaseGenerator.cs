using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    public MoonGenerator moonGenerator;
    public GameObject basePrefab;
    public LunarLander lunarLander;
    public ScoreManager scoreManager;
    private Vector2[] baseCoordinates;

    private int fuelDistanceRatio = 5;

    float computeFuelAmount(int index) {
        // 대충 현재 base 좌표와 다음 base좌표 사이 거리를 측정하여 비례해서 연료 주기
        if (index < baseCoordinates.Length-1) {
            Vector2 displacement = baseCoordinates[index + 1] - baseCoordinates[index];
            return displacement.magnitude * fuelDistanceRatio;
        }
        return 1000000f;
    }
    void Start()
    {
        baseCoordinates = moonGenerator.GetBaseCoordinates();
        int baseAmount = baseCoordinates.Length;
        Base[] bases = new Base[baseAmount];

        for (int i = 0; i < baseAmount; i++) {
            GameObject newBase = Instantiate(
                original: basePrefab,
                position: baseCoordinates[i],
                rotation: Quaternion.Euler(0, 0, 0),
                parent: transform);
            Base baseScript = newBase.GetComponent<Base>();
            baseScript.setStage(i);
            baseScript.lunarLander = lunarLander;
            baseScript.scoreManager = scoreManager;
            baseScript.SetFuelNeeded(computeFuelAmount(i));
            bases[i] = baseScript;
        }

        for (int i = 0; i < baseAmount - 1; i++) {
            bases[i].nextBase = bases[i+1]; 
        }
    }

}
