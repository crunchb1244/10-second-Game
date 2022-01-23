using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectile;
    float timer = 0.0f;

    public bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>3.0f&&isOn==true)
        {
           Instantiate(projectile,this.transform);
           timer = 0;
        }
    }
}
