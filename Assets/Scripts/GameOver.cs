using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start(){
        UpdateScore();
    }

    public void PlayGame()
    {
      SceneManager.LoadScene("Scenes/MainLevel");
    }

   public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void UpdateScore(){
        print(PlayerPrefs.GetInt("Score"));
         transform.parent.Find("Score").GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + PlayerPrefs.GetInt("Score");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
