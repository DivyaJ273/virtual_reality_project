using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreakObject : MonoBehaviour
{
    public GameObject brokenPrefab; // Prefab. Broken version of object


    // Called on when an object collides in order to "break" it
    void OnCollisionEnter(Collision col) {
        // Only "breaks" if hit hard enough
        if (col.relativeVelocity.magnitude > 3) {
            // Instantiate a version of brokenPrefab to spawn broken version
            GameObject brokenVersion = Instantiate(brokenPrefab, transform.position, transform.rotation) as GameObject;
            Component[] debris = brokenVersion.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in debris){
                CopyVelocity(gameObject.GetComponent<Rigidbody>(), rb);
            }
            brokenVersion.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
    void CopyVelocity(Rigidbody original, Rigidbody broken)
     {
         Vector3 vOriginal = original.velocity;
         Vector3 vBroken = broken.velocity;


         vBroken.x = vOriginal.x;
         vBroken.z = vOriginal.z;
         broken.velocity = vBroken;
     }
}
