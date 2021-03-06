using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameConstants gameConstants;
    private float[] pitchShift = {1.0f, 1.05f};
    private AudioSource enemyAudio;

    void stopBGM() {
        GameObject mainGameObject = GameObject.Find("UI").GetComponent<MenuController>().mainGameObject;
        AudioSource gameBGM = mainGameObject.GetComponent<AudioSource>();
        gameBGM.Stop();
    }

    void goombaDeathSound() {
        if (pitchShift[1] > 0.0f) {
            pitchShift[1] = 0.0f;
            pitchShift[0] = 1.0f;
        }
        else if (pitchShift[0] <= 1.7f) {
            pitchShift[0] += 0.1f;
        }
        enemyAudio.pitch = pitchShift[0];
        enemyAudio.PlayOneShot(enemyAudio.clip);
    }

    void koopaDeathSound() {
        if (pitchShift[0] > 0.0f) {
            pitchShift[0] = 0.0f;
            pitchShift[1] = 1.05f;
        }
        else if (pitchShift[1] <= 1.75f) {
            pitchShift[1] += 0.1f;
        }
        enemyAudio.pitch = pitchShift[1];
        enemyAudio.PlayOneShot(enemyAudio.clip);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        // subscribe to brick coin break
        GameManager.OnPlayerDeath += stopBGM;
        GameManager.OnGoombaDeath += goombaDeathSound;
        GameManager.OnKoopaDeath += koopaDeathSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
