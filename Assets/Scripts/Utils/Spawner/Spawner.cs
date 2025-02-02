using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> spawnPrefabs = new List<GameObject>();
    public List<Vector2> takenPositions = new List<Vector2>();

    private void Awake()
    {
        GameEventsHandler.current.onLevelGenerated += OnLevelGenerated;
    }

    private void OnLevelGenerated(object sender, System.EventArgs e)
    {
        foreach (var prefab in spawnPrefabs)
        {
            var coord = Level.current.GetRandomPositionInsideRoom();

            var position = Level.CalculatePosition(coord);

            while(takenPositions.Contains(position))
            {
                coord = Level.current.GetRandomPositionInsideRoom();
                position = Level.CalculatePosition(coord);
            }

            takenPositions.Add(position);


            var go = Instantiate<GameObject>(prefab, position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
