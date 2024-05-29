using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildMap : MonoBehaviour
{
    public Tile grassTile;
    public Tile dirtTile;
    public Tilemap highlightMap;
    private int max_per_iteration = 20;
    private Vector3Int previous;

    // do late so that the player has a chance to move in update if necessary
    private void LateUpdate()
    {
        // get current grid location
        Vector3Int currentCell = highlightMap.WorldToCell(new Vector2(transform.position.x, -1f));
        // add one in a direction (you'll have to change this to match your directional control)
        currentCell.x += 1;

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            for (int i = 0; i < max_per_iteration; i++)
            {
                highlightMap.SetTile(currentCell, grassTile);
                highlightMap.SetTile(currentCell + new Vector3Int(0, -1), dirtTile);
                highlightMap.SetTile(currentCell + new Vector3Int(0, -2), dirtTile);
                currentCell.x++;
            }
            // save the new position for next frame
            previous = currentCell;
        }
        Vector3Int passedCell = highlightMap.WorldToCell(new Vector2(transform.position.x - 10f, -1f));
        for (int i = 0; i < max_per_iteration; i++)
        {
            highlightMap.SetTile(passedCell, null);
            highlightMap.SetTile(passedCell + new Vector3Int(0, -1), null);
            highlightMap.SetTile(passedCell + new Vector3Int(0, -2), null);
            passedCell.x++;
        }
    }
}
