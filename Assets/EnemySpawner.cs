using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject player;
    RuntimeAnimatorController [] animators = new RuntimeAnimatorController[3];
    BaseEnemy[] scripts = new BaseEnemy[3];

    float TimerWaitTime = 0f ;
    float TimerMaxWaitTime = 4f;
    float TimerMinWaitTime = 1f;
    private IEnumerator timerCoroutine(){
        float currentTime = 0f;
        TimerWaitTime = Random.Range(TimerMinWaitTime,TimerMaxWaitTime);
        while(currentTime < TimerWaitTime){
            yield return null;
            currentTime += Time.deltaTime;
        }
        spawnEnemy();
        StartCoroutine(timerCoroutine());
    } 
    private void spawnEnemy(){

        GameObject instance = Instantiate(enemyPrefab, transform);
        instance.GetComponent<Enemy>().player = player;
        instance.GetComponent<Animator>().runtimeAnimatorController = animators[Random.Range(0,animators.Length)];
        instance.transform.position = player.transform.position + new Vector3(10,0,0);
    }

    private RuntimeAnimatorController[] getEnemyAnimators(){
        return Resources.LoadAll<RuntimeAnimatorController>("Enemies/Animators");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        animators = getEnemyAnimators();
        StartCoroutine(timerCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
