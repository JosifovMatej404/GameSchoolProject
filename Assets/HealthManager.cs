using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject healthObject;
    [SerializeField] GameObject healthContainer;
    int healthCount = 0;

    public void PlayerTakeDamage()
    {
        Destroy(healthContainer.transform.GetChild(0).gameObject);
        healthCount++;
    }
    public void PlayerHeal()
    {
        Instantiate(healthObject, healthContainer.transform);
        healthCount--;
    }
}
