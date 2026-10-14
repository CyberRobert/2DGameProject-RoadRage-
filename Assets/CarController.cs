using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour {
    public Transform transform;
    public float maxYPos = -2f;
    public float minYPos = -15f;
    public GameObject gameOverPanel;
    public float speed = 6f; // speed of raceCar
    public float rotationSpeed = 4f; //speed in which raceCar will rotate
    public CarSounds carSound;


    void Start()
    {
        carSound = GetComponent<CarSounds>();
        gameOverPanel.SetActive(false); // hide the game over panel at the start
        Time.timeScale = 1;
    }

    void Update()
    {
        //Move the car left, right, up and down
        if(Input.GetKey(KeyCode.UpArrow)) // move car up
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow)) // tilt and move car right
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)) // tilt and move car left
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 45), rotationSpeed * Time.deltaTime);
        }
        if(transform.rotation.z != 90) // return car to face up smoothly
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10f * Time.deltaTime);
        }
        if(transform.position.y > -15) // slow car down
        {
            transform.position -= new Vector3(0, speed/2 * Time.deltaTime, 0);
        }
        
        // restrict car from moving too far left, right, up or down
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6.4f, 4.1f);
        pos.y = Mathf.Clamp(pos.y, minYPos, maxYPos);
        transform.position = pos;
    }
    
    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("semi") || collidedWith.CompareTag("car")) {
            Time.timeScale = 0; // stop the game
            gameOverPanel.SetActive(true); // show the game over panel
            carSound.carSound.Stop();
        }
    }
}
