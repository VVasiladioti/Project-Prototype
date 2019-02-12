using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;
    public static float TerrainLeft, TerrainRight, TerrainTop, TerrainBottom, TerrainWidth, TerrainLenght, TerrainHeight; 

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Awake() {
        TerrainLeft= WorldTerrain.transform.position.x;
        TerrainBottom = WorldTerrain.transform.position.z;
        TerrainWidth = WorldTerrain.terrainData.size.x;
        TerrainLenght= WorldTerrain.terrainData.size.z;
        TerrainHeight = WorldTerrain.terrainData.size.y;
        TerrainRight = TerrainLeft + TerrainWidth;
        TerrainTop = TerrainBottom + TerrainLenght;

        InstantiateRandomPosition("Prefabs/Cube1", 10 , 5f);
        InstantiateRandomPosition("Prefabs/Cube2", 10 , 5f);
    }

    public void InstantiateRandomPosition (string Resource, int Amount, float AddedHeight) {
        var i=0;
        float TerrainHeight = 0f;
        RaycastHit hit;
        float randomPositionX, randomPositionY, randomPositionZ;
        Vector3 randomPosition = Vector3.zero;

        do {
            i++;
            randomPositionX = Random.Range (TerrainLeft, TerrainRight);
            randomPositionZ = Random.Range (TerrainBottom, TerrainTop);

            if ( Physics.Raycast(new Vector3(randomPositionX, 9999f, randomPositionZ),Vector3.down, out hit, Mathf.Infinity, TerrainLayer)) {
                TerrainHeight = hit.point.y;
            }
            randomPositionY = TerrainHeight + AddedHeight;
            randomPosition = new Vector3 (randomPositionX, randomPositionY, randomPositionZ);
            
            Instantiate(Resources.Load(Resource, typeof(GameObject)), randomPosition, Quaternion.identity);

        } while (i< Amount);
    }
}
