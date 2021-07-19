using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public AudioClip[] audioClips;
    public static int upperBound = 5;
    private bool scoreAdded = false;
    private AudioSource myAudioSource;

    void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!scoreAdded) {
            scoreAdded = true;
            ScoreManager.score++;
            ScoreManager.randScore++;
            if(ScoreManager.randScore > 10 && upperBound > 2) {
                ScoreManager.randScore = 0;
                upperBound--;
            }
            int rand1 = Random.Range(0,upperBound);
            int rand2 = Random.Range(0,upperBound);

            if(other.gameObject.tag == "Player" && rand1 == rand2) {
                AudioClip pointAudio = audioClips[0];
                myAudioSource.PlayOneShot(pointAudio);
                int randX = Random.Range(0,4);
                switch(randX) {
                    case 0:
                        other.gameObject.GetComponent<Renderer>().material.color = Color.red;
                        Player.colorChangeRed = true;
                        break;
                    case 1:
                        other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        Player.colorChangeBlue = true;
                        break;
                    case 2:
                        other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                        Player.colorChangeYellow = true;
                        break;
                    case 3:
                        other.gameObject.GetComponent<Renderer>().material.color = Color.green;
                        Player.colorChangeGreen = true;
                        break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<Renderer>().material.color != this.GetComponent<Renderer>().material.color) {
            AudioClip deathAudio = audioClips[1];
            myAudioSource.PlayOneShot(deathAudio);
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Player.moveSpeed = 0f;
            Player.playerDead = true;
            GameManager.showEverything = true;
        }
    }
}
