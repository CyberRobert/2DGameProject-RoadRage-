using UnityEngine;
using Unity.UI;

public class GameOverPanel : MonoBehaviour {
    public GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(false); // hide the game over panel at the start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
