using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnColors : MonoBehaviour
{    
    private int position1,position2,position3,position0;

    // Start is called before the first frame update
    void Start()
    {
        position0 = Mathf.RoundToInt(Random.Range(0,4));
        do {
            position1 = Mathf.RoundToInt(Random.Range(0,4));
        } while(position1 == position0);
        do {
            position2 = Mathf.RoundToInt(Random.Range(0,4));
        } while(position2 == position0 || position2 == position1);
        do {
            position3 = Mathf.RoundToInt(Random.Range(0,4));
        } while(position3 == position0 || position3 == position1 || position3 == position2);
        
        this.transform.GetChild(position1).GetComponent<Renderer>().material.color = Color.red;
        this.transform.GetChild(position2).GetComponent<Renderer>().material.color = Color.blue;
        this.transform.GetChild(position3).GetComponent<Renderer>().material.color = Color.green;
        this.transform.GetChild(position0).GetComponent<Renderer>().material.color = Color.yellow;
    }
}
