using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float timeLive = 1.5f;

    private void Update()
    {
        timeLive -= Time.deltaTime;
        if (timeLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
