using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool startCountDown,activateScoreBox,showEverything,beginGame1,beginGame0;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject titleText2;
    [SerializeField] GameObject bodyText;
    [SerializeField] GameObject creditsText;
    [SerializeField] GameObject backgroundImage;
    [SerializeField] GameObject backgroundImage2;
    [SerializeField] GameObject highScoreText;
    [SerializeField] GameObject endScoreText;
    [SerializeField] GameObject messageText;
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject endFade;
    [SerializeField] GameObject scoreBox;
    private int counter;

    void Awake()
    {
        activateScoreBox = false;
        startCountDown = false;
        backgroundImage2.SetActive(false);
        StartCoroutine(StartFadeRoutine());
        endFade.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        titleText2.SetActive(false);
        beginGame0 = false;
        beginGame1 = false;
        showEverything = false;
        counter = 0;
        titleText.GetComponent<Animator>().enabled = false;
        creditsText.GetComponent<Animator>().enabled = false;
        bodyText.GetComponent<Animator>().enabled = false;
        backgroundImage.GetComponent<Animator>().enabled = false;
        titleText.SetActive(true);
        bodyText.SetActive(true);
        creditsText.SetActive(true);
        backgroundImage.SetActive(true);
        endScoreText.SetActive(false);
        highScoreText.SetActive(false);
        messageText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreBox.GetComponent<Text>().text = ScoreManager.score.ToString();
        if(Input.GetMouseButtonDown(0) && counter < 2) {
            counter++;
            if(beginGame0) {
                Player.attempts++;
                if(Player.attempts == 1) {
                    playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    playerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,6.5f);
                }
                beginGame1 = true;
                Player.startBeanMovement = true;
            }
            if(!beginGame0) {
                StartCoroutine(StartTextFadeOut());
                beginGame0 = true;
            } 
        }

        if(showEverything) {
            StartCoroutine(CountDown());
            scoreBox.SetActive(false);
            backgroundImage2.SetActive(true);
            titleText2.SetActive(true);
            endScoreText.GetComponent<Text>().text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore",0);
            endScoreText.SetActive(true);
            highScoreText.GetComponent<Text>().text = "SCORE: " + ScoreManager.score;
            highScoreText.SetActive(true);
            messageText.SetActive(true);
        }
        if(startCountDown && showEverything && Input.GetMouseButtonDown(0)) {
            showEverything = false;
            startCountDown = false;
            StartCoroutine(EndFadeRoutine());
        }
        if(activateScoreBox) {
            activateScoreBox = false;
            scoreBox.SetActive(true);
        }
    }

    private IEnumerator CountDown() {
        yield return new WaitForSeconds(.5f);
        startCountDown = true;
    }

    private IEnumerator StartTextFadeOut() {
        titleText.GetComponent<Animator>().enabled = true;
        creditsText.GetComponent<Animator>().enabled = true;
        bodyText.GetComponent<Animator>().enabled = true;
        backgroundImage.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(.5f);
        titleText.SetActive(false);
        bodyText.SetActive(false);
        creditsText.SetActive(false);
        backgroundImage.SetActive(false);
        titleText.GetComponent<Animator>().enabled = false;
        creditsText.GetComponent<Animator>().enabled = false;
        bodyText.GetComponent<Animator>().enabled = false;
        backgroundImage.GetComponent<Animator>().enabled = false;
    }

    private IEnumerator StartFadeRoutine() {
        startFade.SetActive(true);
        yield return new WaitForSeconds(.5f);
        startFade.SetActive(false);
    }

    private IEnumerator EndFadeRoutine() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
