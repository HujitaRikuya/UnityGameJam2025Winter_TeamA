using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("発生させるエフェクト")]
    private ParticleSystem particle;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision .gameObject.tag=="Enemies")
        {
            ParticleSystem newParticle = Instantiate(particle);

            newParticle.transform.position = this.transform.position;

            newParticle.Play();

            Destroy(this.gameObject);
        
        }
    }
}
