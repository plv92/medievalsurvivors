using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject chunkPrefab;
    public int chunkSize = 20;
    public int viewDistance = 2;

    private Dictionary<Vector2, GameObject> loadedChunks = new Dictionary<Vector2, GameObject>();

    void Update()
    {
        LoadChunks();
    }

    void LoadChunks()
    {
        Vector2 playerChunkPos = new Vector2(Mathf.FloorToInt(player.transform.position.x / chunkSize), Mathf.FloorToInt(player.transform.position.y / chunkSize));

        for (int y = -viewDistance; y <= viewDistance; y++)
        {
            for (int x = -viewDistance; x <= viewDistance; x++)
            {
                Vector2 chunkPos = new Vector2(playerChunkPos.x + x, playerChunkPos.y + y);

                if (!loadedChunks.ContainsKey(chunkPos))
                {
                    GameObject chunk = Instantiate(chunkPrefab, chunkPos * chunkSize, Quaternion.identity);
                    loadedChunks.Add(chunkPos, chunk);
                }
            }
        }

        List<Vector2> keysToRemove = new List<Vector2>();

        foreach (KeyValuePair<Vector2, GameObject> chunk in loadedChunks)
        {
            if (Mathf.Abs(chunk.Key.x - playerChunkPos.x) > viewDistance || Mathf.Abs(chunk.Key.y - playerChunkPos.y) > viewDistance)
            {
                Destroy(chunk.Value);
                keysToRemove.Add(chunk.Key);
            }
        }

        foreach (Vector2 key in keysToRemove)
        {
            loadedChunks.Remove(key);
        }
    }
}