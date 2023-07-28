using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private InFocusComo pressed;
    GameObject[] celestials;
    private Gravity grav;
    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        m_rigidbody = GetComponent<Rigidbody>();
        pressed = GetComponent<InFocusComo>();
        grav = GetComponent<Gravity>();
    }

    void Update()
    {
        //
        if (pressed.InFocus)
        {
            UIVELO.UpdateVelo(gameObject.name, System.Math.Round(m_rigidbody.velocity.magnitude, 2), grav.acceleration.magnitude,
                transform.localScale.x / 2, m_rigidbody.mass);
        }

    }

    void OnMouseDown()
    {
        // Debug.Log($"{gameObject.name} was hit, velocity: {m_rigidbody.velocity}, magnitude: {System.Math.Round(m_rigidbody.velocity.magnitude, 2)}");
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        foreach (var c in celestials)
        {
            c.GetComponent<InFocusComo>().InFocus = false; 
        }
        pressed.InFocus = !(pressed.InFocus);
    }
}
