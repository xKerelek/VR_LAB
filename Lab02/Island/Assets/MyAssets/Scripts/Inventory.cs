using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    public static int charge = 0;
    public AudioClip collectSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CellPickup()
    {
        audioSource.PlayOneShot(collectSound);
        charge++;
    }

}
