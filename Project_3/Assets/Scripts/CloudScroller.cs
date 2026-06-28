using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroller : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.01f;

    Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    
    void Update()
    {
        Vector2 offset = rend.material.mainTextureOffset;

        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;

        rend.material.mainTextureOffset = offset;
    }
}
