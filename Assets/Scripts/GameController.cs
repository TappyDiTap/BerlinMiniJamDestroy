using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject beginningPlayer;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera virtualCamera;
    public float rotationSpeed = 1.0f;
    public int lives = 3;
    public float gravity = 1.0f;

    private Character player;

    private Vector3 respawnPosition;
    private bool rotateRight = false;
    private bool rotateLeft = false;
    private float rotateAmount = 0.0f;
    private float[] rotateTo = {0.0f, 90.0f, 180.0f, 270.0f};
    private Vector3[] gravityDirection = {Vector3.down, Vector3.right, Vector3.up, Vector3.left};
    private int rotationSetting = 0;

    void Start() {
        respawnPosition = beginningPlayer.transform.position;
        virtualCamera.Follow = beginningPlayer.transform;
        player = beginningPlayer.GetComponent<Character>();
        rotateAmount = 0.0f;
        print("Player : " + player);
    }

    // Update is called once per frame
    void Update() {
        //if(player == null) return;
        // revive player
        if(player.alive == false) {
            if(lives > 1) {
                lives--;
                SpawnPlayer();
            }
            else {
                // game over
                SceneManager.LoadScene("GameOver");
            }
        }

        if(Input.GetButton("RotateLeft") && !rotateLeft) {
            RotateLeft();
        }
        else if(Input.GetButton("RotateRight") && !rotateRight) {
            RotateRight();
        }

        if(rotateLeft || rotateRight) {
            print("Hello2");
            float change = rotationSpeed;
            float rotationZ = transform.rotation.eulerAngles.z;
            if(rotateLeft) {
                change = -rotationSpeed;
            }

            rotateAmount += rotationSpeed;
            
            // done rotating
            if(rotateAmount >= 90.0f) {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotateTo[rotationSetting]);
                print("Angle " + rotateTo[rotationSetting]);
                rotateLeft = false;
                rotateRight = false;
                rotateAmount = 0.0f;

                // finished rotating, set physics
                Physics.gravity = gravityDirection[rotationSetting] * gravity;
                UnfreezePhysics();
            }

            else {
                transform.Rotate(0, 0, rotationSpeed, Space.World);
            }
        }
    }

    public void FreezePhysics() {
        Time.timeScale = 0.0f;
    }

    public void UnfreezePhysics() {
        Time.timeScale = 1.0f;
    }

    public void RotateLeft() {
        FreezePhysics();
        rotateLeft = true;
        rotationSetting++;
        if(rotationSetting > 3) rotationSetting = 0;
    }

    public void RotateRight() {
        FreezePhysics();
        rotateRight = true;
        rotationSetting--;
        if(rotationSetting < 0) rotationSetting = 3;
    }


    public void SpawnPlayer() {
        GameObject obj = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
        player = obj.GetComponent<Character>();
        player.alive = true;
        virtualCamera.Follow = obj.transform;
    }
}
