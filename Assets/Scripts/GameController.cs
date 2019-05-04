using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public Spawn instance;
    public GameObject playerPrefab;
    public Vector3 respawnPosition;
    public int lives = 3;

    private Character player;

    // Singleton
    void Start() {
        if(instance == null) {
            instance = this;
            SpawnPlayer();
        }
        else {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        // revive player
        if(player.alive == false) {
            if(lives > 1) {
                lives--;
                SpawnPlayer();
            }
        } 
    }

    public void SpawnPlayer() {
        GameObject obj = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
        player = obj.GetComponent<Character>();
        player.alive = true;
    }
}
