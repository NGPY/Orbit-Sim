using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    readonly float G = 10;
    GameObject[] celestials;
    public Vector3 Velocity;
    public Vector3 acceleration;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = Velocity;
    }

    void OnEnable()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
    }
    private void FixedUpdate()
    {
        simGravity();
        acceleration = (m_rigidbody.velocity - Velocity) / Time.fixedDeltaTime;
        Velocity = m_rigidbody.velocity;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void simGravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

}
