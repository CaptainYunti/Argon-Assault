using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{

    [SerializeField] float secondsToWaitAfterCrash = 2f;
    [SerializeField] ParticleSystem explosionParticle;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<PlayerControls>().enabled = false;
        explosionParticle.Play();
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mesh in meshRenderers)
        {
            mesh.enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadScene", secondsToWaitAfterCrash);
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
