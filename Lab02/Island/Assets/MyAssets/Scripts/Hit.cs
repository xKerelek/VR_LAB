using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision theObject)
    {
        Debug.Log("Kolizja wykryta z obiektem: " + theObject.gameObject.name);

        if (theObject.gameObject.name == "coconut")
        {
            Debug.Log("Wilk zosta³ trafiony kokosem!");
            GetComponent<Animator>().SetTrigger("hit");
        }
    }
}
