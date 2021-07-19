using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float moveSpeed = 6.5f;
    public static int attempts = 0;
    [SerializeField] GameObject blueExplosion;
    [SerializeField] GameObject greenExplosion;
    [SerializeField] GameObject yellowExplosion;
    [SerializeField] GameObject redExplosion;
    public static bool startBeanMovement,playerDead,colorChangeBlue,colorChangeRed,colorChangeYellow,colorChangeGreen;
    private Rigidbody2D myRigidbody;
    public static Vector2 startingGravityValue;

    void Awake()
    {
        colorChangeBlue = false;
        colorChangeGreen = false;
        colorChangeYellow = false;
        colorChangeRed = false;
        startBeanMovement = false;
        playerDead = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6.5f;
        this.GetComponent<Renderer>().material.color = Color.blue;
        myRigidbody = this.GetComponent<Rigidbody2D>();
        startingGravityValue = Physics2D.gravity;
        if(startingGravityValue == Vector2.zero) {
            startingGravityValue = new Vector2(0,-9.8f);
        }
        Physics2D.gravity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(colorChangeBlue) {
            colorChangeBlue = false;
            GameObject blueChangeExp = Instantiate(blueExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        if(colorChangeRed) {
            colorChangeRed = false;
            GameObject redChangeExp = Instantiate(redExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        if(colorChangeYellow) {
            colorChangeYellow = false;
            GameObject yellowChangeExp = Instantiate(yellowExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        if(colorChangeGreen) {
            colorChangeGreen = false;
            GameObject greenChangeExp = Instantiate(greenExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        if(startBeanMovement) {
            GameManager.activateScoreBox = true;
            GroundSpawner.allowColumnProduction = true;
            Physics2D.gravity = startingGravityValue;
            if(Input.GetMouseButtonDown(0)) {
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,moveSpeed);
            }
        }
    }
}
