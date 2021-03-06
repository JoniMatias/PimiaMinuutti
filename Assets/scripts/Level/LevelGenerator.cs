using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField] private List<LevelAssetList> levels;

    [Header("Bounds")]
    public float boundMinX;
    public float boundMaxX;
    public float boundMinY;
    public float boundMaxY;

    [SerializeField] private List<GameObject> spawnPositions;
    private List<GameObject> unusedPositions = new List<GameObject>();

    private LevelAssetList currentLevel = null;

    void Start() {
        currentLevel = levels[Random.Range(0, levels.Count)];
        int wallCount = Random.Range(currentLevel.wallCountMin, currentLevel.wallCountMax+1);
        InitializeUnusedPositions();

        Instantiate<GameObject>(currentLevel.floorSpritePrefab, null);

        for (int i=0; i<wallCount; ++i) {
            GameObject wallPrefab = currentLevel.walls[Random.Range(0, currentLevel.walls.Count)];
            int positionIndex = Random.Range(0, unusedPositions.Count);
            Vector3 position = unusedPositions[positionIndex].transform.position;
            GameObject wallObject = Object.Instantiate<GameObject>(wallPrefab, null);
            wallObject.transform.position = position;
            unusedPositions.RemoveAt(positionIndex);
        }

        int decorCount = Random.Range(currentLevel.decorCountMin, currentLevel.decorCountMax+1);

        for (int i=0; i<decorCount; ++i) {
            GameObject decorPrefab = currentLevel.decorations[Random.Range(0, currentLevel.decorations.Count)];
            Vector3 position = new Vector3(Random.Range(boundMinX, boundMaxX), Random.Range(boundMinY, boundMaxY));
            GameObject decor = Instantiate<GameObject>(decorPrefab, null);
            decor.transform.position = position;
        }

        GameObject centerObject = Instantiate(currentLevel.centerObject, null);
        centerObject.transform.position = Vector3.zero;

    }

    void InitializeUnusedPositions() {
        foreach (GameObject go in spawnPositions) {
            unusedPositions.Add(go);
        }
    }
}
