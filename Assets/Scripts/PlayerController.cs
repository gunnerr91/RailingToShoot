using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed = 20f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 8f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float rotationPitchFactor = -30f;

    [SerializeField] float positionYawFactor = 1.5f;

    [SerializeField] float rotationRollFactor = 20f;

    [SerializeField] GameObject[] guns;

    float horizontalThrow, verticalThrow;

    bool isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        //isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead) return;
        ProcessPlayerPosition();
        ProcessPlayerRotation();
        ProcessFiring();
    }

    public void RemoveControl()
    {
        isPlayerDead = true;
        print("The red baron has fallen!");

    }

    private void ProcessPlayerRotation()
    {

        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * rotationPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * rotationRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessPlayerPosition()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        var xOffSet = horizontalThrow * speed * Time.deltaTime;
        var rawXPosition = transform.localPosition.x + xOffSet;
        var clampRawXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);

        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        var yOffSet = verticalThrow * speed * Time.deltaTime;
        var rawYPosition = transform.localPosition.y + yOffSet;
        var clampRawYPosition = Mathf.Clamp(rawYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampRawXPosition, clampRawYPosition, transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
