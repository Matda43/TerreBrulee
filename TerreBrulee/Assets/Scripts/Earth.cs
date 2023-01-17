using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour
{
    public GameObject endMenu;
    public TextMeshProUGUI endText;

    public AudioClip comet;
    public AudioClip eruption;

    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Comet")
        {
            audiosource.clip = comet;
            audiosource.volume = 0.1f;
            audiosource.Play();
        }
        else
        {
            audiosource.clip = eruption;
            audiosource.volume = 0.7f;
            audiosource.Play();
        }
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
