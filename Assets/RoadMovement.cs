using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadMovement : MonoBehaviour {
    public Renderer meshRenderer;
    float speed = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0,speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
