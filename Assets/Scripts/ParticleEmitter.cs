using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
     public GameObject targetCube; // Drag the second cube into this slot
    public ParticleSystem particleSystemPrefab; // Create a prefab by dragging a Particle System into the Assets folder

    private ParticleSystem particleSystemInstance;

    void Start()
    {
        // Instantiate the Particle System
        particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

        // Set the target for the particle system
        var mainModule = particleSystemInstance.main;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
        var shapeModule = particleSystemInstance.shape;
        shapeModule.rotation = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        // Emit particles towards the target cube
       
        particleSystemInstance.transform.LookAt(targetCube.transform.position);
        particleSystemInstance.transform.position = transform.position;
    }
}
