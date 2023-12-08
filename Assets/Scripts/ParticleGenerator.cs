using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public int maxParticles = 1000000;
    public float sphereRadius = 5f;

    private ParticleSystem particleSystemInstance;

    void Start()
    {
        // Instantiate the Particle System
        particleSystemInstance = GetComponent<ParticleSystem>();
        particleSystemInstance.maxParticles = maxParticles;

        // Set up initial particles
        EmitParticles(maxParticles);
    }

    void Update()
    {
        // Emit additional particles if needed
        if (particleSystemInstance.particleCount < maxParticles)
        {
            int particlesToEmit = maxParticles + particleSystemInstance.particleCount;
            EmitParticles(particlesToEmit);
        }

        // Update particle positions
        UpdateParticlePositions();
    }

    void EmitParticles(int count)
    {
        // Emit particles with random positions within the sphere
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = Random.onUnitSphere * sphereRadius;

        particleSystemInstance.Emit(emitParams, count);
    }

    void UpdateParticlePositions()
    {
        // Keep particles within the sphere
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[maxParticles];
        int particleCount = particleSystemInstance.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            Vector3 toCenter = particles[i].position.normalized * sphereRadius;
            particles[i].position = Vector3.Slerp(particles[i].position, toCenter, Time.deltaTime);
        }

        particleSystemInstance.SetParticles(particles, particleCount);
    }
}
