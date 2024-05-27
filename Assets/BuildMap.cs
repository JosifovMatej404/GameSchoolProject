using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildMap : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;
    private int max_per_iteration = 10;
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
                highlightMap.SetTile(currentCell, highlightTile);
                currentCell.x++;
            }
            // save the new position for next frame
            previous = currentCell;
        }
    }
}
