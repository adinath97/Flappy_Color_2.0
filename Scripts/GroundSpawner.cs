using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    public static bool allowColumnProduction;
    private Vector3 nextSpawnPoint;
    private GameObject tempWithSpawnPoint;
    private bool first;
    
    // Start is called before the first frame update
    private void Start() {
        allowColumnProduction = false;
        first = true;
        SpawnTile();
        SpawnTile();
    }

    public void SpawnTile() {
        if(first) {
            first = false;
            GameObject temp = Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
            tempWithSpawnPoint = temp;
            return;
        }
        else {
            nextSpawnPoint = tempWithSpawnPoint.transform.GetChild(5).transform.position;
            GameObject temp = Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
            if(allowColumnProduction) {
                temp.GetComponent<GroundTile>().startColumnProduction = true;
            }
            tempWithSpawnPoint = temp;
        }
        
    }
}
