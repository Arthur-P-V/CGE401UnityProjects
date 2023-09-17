/*
* Arthur Peterson-Veatch
* Challenge 2
* This script controls the player functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(ShootDelayCoroutine());
        }
    }

    IEnumerator ShootDelayCoroutine() {
        yield return new WaitForSeconds(0.5f);

        canShoot = true;
    }
}
