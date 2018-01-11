using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerMovement: MonoBehaviour
{
    private float mx;
    private float my;
    public GameObject dartPrefab;
    public Transform dartSpawn;
    void Awake()
    {

    }
  
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        mx += Input.GetAxis("Mouse X") * Time.deltaTime * 150.0f;
        my -= Input.GetAxis("Mouse Y") * Time.deltaTime * 150.0f;
        transform.eulerAngles = new Vector3(my,mx,0.0f);
        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
    }

    void Fire()
    {
        
        var dart = (GameObject)Instantiate(
            dartPrefab,
            dartSpawn.position,
            dartSpawn.rotation);

        // Add velocity to the bullet
        dart.GetComponent<Rigidbody>().velocity = dart.transform.forward * 15;

        // Destroy the bullet after 2 seconds
        // Destroy(dart, 2.0f);
    }
}
