using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;

    public void PlaceGround(float height)
    {

        GameObject ground = Instantiate(groundPrefab);


        Vector3 position = new Vector3(0, height, 0);
        ground.transform.position = position;
    }

    public void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PlaceGround(mousePosition.y);
    }

    public void DestroyGround(GameObject ground)
    {
        Destroy(ground);
    }

    public void ChangeSize(GameObject ground, Vector3 newSize)
    {
        ground.transform.localScale = newSize;
    }
}
