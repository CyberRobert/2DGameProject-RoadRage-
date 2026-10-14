using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Traffic : MonoBehaviour {
    public Transform transform;
    public float speed = 4f;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,speed * Time.deltaTime, 0);

        if (transform.position.y < -32)
        {
            Destroy(gameObject);
        }
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }
}
