using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        BeginDeathSequence();
    }

    void BeginDeathSequence()
    {
        SendMessage("RemoveControl");
    }
}
