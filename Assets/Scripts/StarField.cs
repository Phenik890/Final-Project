using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    private ParticleSystem ps;
    public GameController gamecontroller;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        var main = ps.main;

        if (gamecontroller.score >= 250)
        {
            main.simulationSpeed = 20.0f;
        }
    }
}
