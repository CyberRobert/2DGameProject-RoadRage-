using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CarSounds : MonoBehaviour {
    public float minPitch = 1f;
    public float maxPitch = 3f;
    public AudioSource carSound;
    public CarController carController;

    void Start() {
        carController = GetComponent<CarController>();
        carSound = GetComponent<AudioSource>();
        carSound.Play(); // play the car sound at the start
    }

    // Update is called once per frame
    void Update() {
        float currentPos = carController.transform.position.y;
        float normalizedPos = Mathf.InverseLerp(carController.minYPos,carController.maxYPos,currentPos);
        carSound.pitch = Mathf.Lerp(minPitch,maxPitch,normalizedPos);
    }
}
