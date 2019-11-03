using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition)<PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart,lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        if(player.coinamount/2 > 3)
        {
            lastLevelPartTransform.Find("CoinHolder").gameObject.SetActive(false);
        }
        else
        {
            lastLevelPartTransform.Find("CoinHolder").gameObject.SetActive(true);
        }
    }

    private Transform SpawnLevelPart(Transform LevelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


}
