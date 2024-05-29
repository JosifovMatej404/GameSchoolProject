using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MenuClouds : MonoBehaviour
{
    private Vector3 startingPos;
    private float viewportSize;
    public float speed;
    public Camera mainCamera;

    private void Start()
    {
        startingPos = transform.position;
        viewportSize = mainCamera.pixelRect.width;
    }

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x > startingPos.x + viewportSize)
        {
            transform.position = startingPos;
        }
        else if (transform.position.x < startingPos.x - viewportSize)
        {
            transform.position = startingPos;
        }
    }
}
