using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void startGame() {
        SceneManager.LoadScene("SampleScene");
    }
}
