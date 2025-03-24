using UnityEngine;

public class Base : MonoBehaviour
{
    private int stage;
    private float fuelNeeded;
    public ScoreManager scoreManager;
    public LunarLander lunarLander;
    public Base nextBase;
    private SpriteRenderer spriteRenderer;
    private Color baseRed = new Color(240f/255f, 10f/255f, 10f/255f);
    private Color baseGreen = new Color(39f/255f, 226f/255f, 83f/255f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void setStage(int num) {
        stage = num;
    }
    public void SetFuelNeeded(float fuelLevel) {
        fuelNeeded = fuelLevel;
    }
    public void TurnRed() {
        spriteRenderer.color = baseRed;
    }
    public void TurnGreen() {
        spriteRenderer.color = baseGreen;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Lunar Lander") {
            if(scoreManager.IsScored(stage) || stage == 0) {
                nextBase.TurnRed();
                TurnGreen();
                scoreManager.UpdateScores(stage);
                lunarLander.SetFuel(fuelNeeded);
            }
        }
    }
}
