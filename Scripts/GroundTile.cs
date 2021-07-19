using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject columnPrefab;
    public static float moveSpeed = .1f;
    public bool rotateUpDown,closeGap,moveUp,startColumnProduction;
    GameObject columnInstance,columnInstance1,columnInstance2;
    GroundSpawner groundSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = .5f;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if(startColumnProduction) {
            columnInstance = Instantiate(columnPrefab,this.transform.GetChild(2).transform.position,Quaternion.identity);
            columnInstance.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
            columnInstance1 = Instantiate(columnPrefab,this.transform.GetChild(3).transform.position,Quaternion.identity);
            columnInstance1.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
            columnInstance2 = Instantiate(columnPrefab,this.transform.GetChild(4).transform.position,Quaternion.identity);
            columnInstance2.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.playerDead) {
            moveSpeed = 0;
        }
        this.transform.position += new Vector3(-moveSpeed * Time.deltaTime * 8f,0,0); //make framerate independent
        /*
        if(startColumnProduction) {
            if(columnInstance.transform.position != endPosition.position) {
                columnInstance.transform.position = Vector3.MoveTowards(columnInstance.transform.position,endPosition.position,moveSpeed * Time.deltaTime);
            }
            if(columnInstance.transform.position == endPosition.position) {
                Transform temp = endPosition;
                endPosition = startPosition;
                startPosition = temp;
            }  
        }
        */
        if(Player.playerDead) {
            CancelInvoke("DestroySelf");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !Player.playerDead) {
            groundSpawner.SpawnTile();
            Invoke("DestroySelf",10.0f);
        }
    }

    private void DestroySelf() {
        Destroy(this.gameObject);
    }
}
