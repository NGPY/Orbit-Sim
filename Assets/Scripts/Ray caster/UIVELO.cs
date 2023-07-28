using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVELO : MonoBehaviour
{
    private Text thisText;
    private static double velocity;
    private static double radius;
    private static double mass;
    private static double acceleration;
    private static string Planetname;
    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = $"{Planetname}'s velocity: {velocity} m/s\nAcceleration: {Math.Round(acceleration, 2)}" +
            $"\nMass: {mass}\nRadius: {radius}\nTimescale: {Time.timeScale}";
        //Debug.Log($"{Planetname}'s velocity: {velocity} m/s\nAcceleration: {Math.Round(acceleration, 2)}" +
        //    $"\nMass: {mass}\nRadius: {radius}");
    }

    public static void UpdateVelo(string planet,double velo, double accel, double rad, double ms)
    {
        velocity = velo;
        acceleration = accel;
        Planetname = planet;
        radius = rad;
        mass = ms;
    }
}
