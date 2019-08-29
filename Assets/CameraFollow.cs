using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField]
    [Range(3, 10)]
    private float xOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xOffset, 0f, -10f);
    }
}
