using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    RuntimeAnimatorController [] animators = new RuntimeAnimatorController[3];
    MonoScript[] scripts = new MonoScript[3];
    GameObject player;

    float TimerWaitTime = 0f ;
    float TimerMaxWaitTime = 4f;
    float TimerMinWaitTime = 1f;
    private IEnumerator timerCoroutine(){
        float currentTime = 0f;
        TimerWaitTime = UnityEngine.Random.Range(TimerMinWaitTime,TimerMaxWaitTime);
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
        var randomID = UnityEngine.Random.Range(0, animators.Length);
        instance.GetComponent<Animator>().runtimeAnimatorController = animators[randomID];
        instance.AddComponent(scripts[randomID].GetClass());
        instance.transform.position = player.transform.position + new Vector3(10,0,0);
    }

    private RuntimeAnimatorController[] getEnemyAnimators(){
        return Resources.LoadAll<RuntimeAnimatorController>("Enemies/Animators");
    }

    private MonoScript[] getEnemyScripts()
    {
        return Resources.LoadAll<MonoScript>("Enemies/Scripts");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animators = getEnemyAnimators();
        scripts = getEnemyScripts();

        //scripts = Resources.LoadAll<MonoScript>("Enemies/Scripts").Where(script => script.GetClass().IsSubclassOf(typeof(BaseEnemy)));
        StartCoroutine(timerCoroutine());
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
