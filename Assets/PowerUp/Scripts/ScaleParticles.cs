using UnityEngine;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
    void Update () {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.main;
        main.startSize = transform.lossyScale.magnitude;
    }
}