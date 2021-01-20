using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the enemy based on time
        transform.eulerAngles = new Vector3(0, 0, Time.time*100);

        // Scale the enemy based on sin curve and time
        transform.localScale = Vector3.one * (Mathf.Sin(Time.time*10)/2+1.5f);
    }
}
