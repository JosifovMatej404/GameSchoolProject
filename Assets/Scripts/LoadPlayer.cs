using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    private GameObject selectedCharacter;

    private void Awake()
    {
        selectedCharacter = characters[PlayerPrefs.GetInt("SelectedCharacter")];
    }

    private void Start()
    {
        var instance = Instantiate(selectedCharacter, transform);
        instance.transform.SetSiblingIndex(1);
        GetComponent<BuildMap>().setPlayer(instance);
        GetComponent<EnemySpawner>().setPlayer(instance);
    }
}
