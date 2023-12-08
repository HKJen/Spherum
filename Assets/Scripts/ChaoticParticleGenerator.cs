using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticParticleGenerator : MonoBehaviour
{
    public int maxParticles = 1000000;
    public float chaosStrength = 1f;
    public float particleSpeed = 5f;
    public float sphereRadius = 10f;

    private ParticleSystem particleSystemInstance;
    private Transform sphereTransform;

    void Start()
    {
        // Instantiate the Particle System
        particleSystemInstance = GetComponent<ParticleSystem>();
        particleSystemInstance.maxParticles = maxParticles;

        // Enable GPU Instancing for better performance
        var mainModule = particleSystemInstance.main;
        //mainModule.useGPUInstancing = true;

        // Set up the sphere transform
        sphereTransform = new GameObject("SphereCollider").transform;
        sphereTransform.parent = transform;
        sphereTransform.localPosition = Vector3.zero;

        // Set up initial particles
        EmitParticles(maxParticles);
    }

    void Update()
    {
        // Update particle positions chaotically within the sphere
        UpdateParticlePositions();
    }

    void EmitParticles(int count)
    {
        // Emit particles within the sphere
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = GetRandomPointInSphere();

        particleSystemInstance.Emit(emitParams, count);
    }

    void UpdateParticlePositions()
    {
        // Move particles chaotically within the sphere
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[maxParticles];
        int particleCount = particleSystemInstance.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            // Apply chaotic movement to particle position
            Vector3 randomOffset = Random.onUnitSphere * chaosStrength;
            particles[i].position += randomOffset * Time.deltaTime * particleSpeed;

            // Ensure particles stay within the sphere
            particles[i].position = Vector3.ClampMagnitude(particles[i].position, sphereRadius);
        }

        particleSystemInstance.SetParticles(particles, particleCount);
    }

    Vector3 GetRandomPointInSphere()
    {
        // Get a random point within the sphere
        Vector3 randomPoint = Random.onUnitSphere * sphereRadius;
        return sphereTransform.TransformPoint(randomPoint);
    }
}
