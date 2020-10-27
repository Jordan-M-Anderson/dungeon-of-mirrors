using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class turretFunc : MonoBehaviour
{ 
    public Transform Target;
    Vector2 Direction;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;
  
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;

        if (Time.time > nextTimeToFire)
        {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
        }
    }
    void shoot()
    {
        Vector2 shoot = Shootpoint.position;
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }


}