using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        var xoffSet = horizontalThrow * speed  *  Time.deltaTime;
        print(xoffSet);
    }
}
