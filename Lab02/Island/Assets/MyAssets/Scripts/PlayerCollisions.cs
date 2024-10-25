using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerCollisions : MonoBehaviour
{
    private GameObject currentDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3)) 
            // zmiana z 3 na 33 powoduje otwarcie drzwi z wiêkszej odleg³oœci gdy na nie patrzymy
        {
            if (hit.collider.gameObject.tag == "playerDoor")
            {
                currentDoor = hit.collider.gameObject;
                currentDoor.SendMessage("DoorCheck");
            }
        }
    }

}
