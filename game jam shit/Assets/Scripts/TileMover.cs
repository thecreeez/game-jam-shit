using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public static TileMover instance = null;

    public List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> toRemove = new List<GameObject>();
    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.getGameSpeed();

        foreach (GameObject tile in instance.tiles)
        {
            tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z - ((20 * speed) * Time.deltaTime));

            if (tile.transform.position.z < -20)
            {
                instance.toRemove.Add(tile);
            }
        }

        foreach(GameObject removedTile in instance.toRemove)
        {
            Destroy(removedTile);
            tiles.Remove(removedTile);
        }

        instance.toRemove.Clear();
    }

    public void clear()
    {
        tiles.Clear();
    }
}
