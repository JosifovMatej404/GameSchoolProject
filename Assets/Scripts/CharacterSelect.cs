using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }

        skins[selectedCharacter].SetActive(true);
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if(selectedCharacter == skins.Length)
        {
            selectedCharacter = 0;
        }

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    
    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter == -1)
        {
            selectedCharacter = skins.Length-1;
        }

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/MainLevel");
    }

    public void OnBackButton()
    {
        transform.parent.transform.parent.Find("Title").GetComponent<TMPro.TextMeshProUGUI>().text = "SAMURAI CRACK";
    }
}
