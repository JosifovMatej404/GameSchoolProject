using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject healthObject;
    [SerializeField] GameObject healthContainer;
    int healthCount = 0;

    public void Start(){
        
    }
    public void PlayerTakeDamage()
    {
        Destroy(healthContainer.transform.GetChild(0).gameObject);
        healthCount++;

        if(healthCount > 3){
            SceneManager.LoadScene("Scenes/GameOver");
        }

    }
    public void PlayerHeal()
    {
        Instantiate(healthObject, healthContainer.transform);
        healthCount--;
    }
}
