using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildMap : MonoBehaviour
{
    private GameObject player;
    public Tile grassTile;
    public Tile dirtTile;
    public Tilemap highlightMap;
    private int max_per_iteration = 35;
    private Vector3Int previous;


    // do late so that the player has a chance to move in update if necessary
    private void LateUpdate()
    {
        // get current grid location
        Vector3Int currentCell = highlightMap.WorldToCell(new Vector2(player.transform.position.x - 2f, -1f));

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            for (int i = 0; i < max_per_iteration; i++)
            {
                if (highlightMap.GetTile(currentCell) != null)
                {
                    currentCell.x++;
                    continue;
                }
                highlightMap.SetTile(currentCell, grassTile);
                highlightMap.SetTile(currentCell + new Vector3Int(0, -1), dirtTile);
                highlightMap.SetTile(currentCell + new Vector3Int(0, -2), dirtTile);
                currentCell.x++;
            }
            // save the new position for next frame
            previous = currentCell;
        }
        Vector3Int passedCell = highlightMap.WorldToCell(new Vector2(player.transform.position.x - max_per_iteration/2, -1f));
        for (int i = 0; i < max_per_iteration; i++)
        {
            if (highlightMap.GetTile(passedCell) == null)
            {
                passedCell.x++;
                continue;
            }
            highlightMap.SetTile(passedCell, null);
            highlightMap.SetTile(passedCell + new Vector3Int(0, -1), null);
            highlightMap.SetTile(passedCell + new Vector3Int(0, -2), null);
            passedCell.x++;
        }
    }
    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
