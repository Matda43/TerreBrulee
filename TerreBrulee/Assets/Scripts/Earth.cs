using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour
{
    public GameObject endMenu;
    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        openEndMessage();
        Time.timeScale = 0;
    }

    void openEndMessage()
    {
        endText.text = "Vous avez sauvé la Terre pendant " + Time.timeSinceLevelLoad + " millions d'années.";
        endMenu.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
