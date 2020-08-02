using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    
    //
    public Enemy enemy;
    public float timeCreate;
    public bool canCreate = true;
    void Update() {
        if (canCreate == true){
            canCreate = false;
            StartCoroutine(createEnemy());
        }
    }

    IEnumerator createEnemy() {
        yield return new WaitForSeconds(timeCreate);
        canCreate = true;
        float randomRange = Random.Range(-10, 10);
        float speed = Random.Range(0.1f, 0.05f);
        Enemy enemyCreate = Instantiate(enemy.gameObject, transform.position + new Vector3(randomRange, 0, 0), transform.rotation).GetComponent<Enemy>();
        enemyCreate.speed = speed;
    }
}
