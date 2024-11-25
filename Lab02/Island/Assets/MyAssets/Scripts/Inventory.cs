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

    // Zapa³ki
    bool haveMatches = false;
    public RawImage matchHudGUI;

    public static int charge = 0;
    public AudioClip collectSound;
    private AudioSource audioSource;

    public Text textHints;
    bool isFireLit = false;

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

    void MatchPickup()
    {
        haveMatches = true;
        audioSource.PlayOneShot(collectSound);
        matchHudGUI.enabled = true;
    }


    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "campfire")
        {
            if(haveMatches)
            {
                LightFire(col.gameObject);
            } 
            else if(!isFireLit)
            {
                textHints.SendMessage("ShowHint", "Móg³bym rozpaliæ ognisko do wezwania pomocy.\nTylko czym...?");
            }
        }
    }

    void LightFire(GameObject campfire)
    {
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem emitter in fireEmitters)
        {
            emitter.Play();
        }  
        campfire.GetComponent<AudioSource>().Play();
        matchHudGUI.enabled = false;
        haveMatches = false;
        isFireLit = true;
    }
}
