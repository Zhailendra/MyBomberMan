using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public LayerMask wallMask;
    public LayerMask breakableWallMask;
    private bool exploded = false;
    public float propagationReduction = 0.5f; 

    public GameObject explosionPrefab;
    public GameObject wallBreakParticlesPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }
    
    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));  

        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, .3f);
    }
    
    private IEnumerator CreateExplosions(Vector3 direction) 
    {
        float remainingRange = 3;

        for (int i = 1; i <= remainingRange; i++) 
        { 
            RaycastHit hit; 

            if (Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, wallMask)) 
            {
                break; 
            } 

            if (Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, breakableWallMask)) 
            {
                Instantiate(wallBreakParticlesPrefab, hit.collider.transform.position, Quaternion.identity);

                Destroy(hit.collider.gameObject);

                Instantiate(explosionPrefab, hit.collider.transform.position, explosionPrefab.transform.rotation);

                remainingRange -= propagationReduction;

                if (remainingRange <= 0)
                    break;

                continue;
            }

            Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);

            yield return new WaitForSeconds(.05f); 
        }
    }

    
    public void OnTriggerEnter(Collider other) 
    {
        if (!exploded && other.CompareTag("Explosion"))
        { 
            CancelInvoke("Explode");
            Explode();
        }  
    }
    
}
