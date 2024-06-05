using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPt;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable XGI = GetComponent<XRGrabInteractable>();
        XGI.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnPt.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnPt.forward * speed;
        Destroy(spawnBullet, 5);
    }
}
