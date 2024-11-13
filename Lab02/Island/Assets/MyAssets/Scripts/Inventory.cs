using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;

    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;

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
        HUDon();
        audioSource.PlayOneShot(collectSound);
        charge++;
        chargeHudGUI.texture = hudCharge[charge];
        meter.material.mainTexture = meterCharge[charge];

    }

    void HUDon()
    {
        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }
    }

}
