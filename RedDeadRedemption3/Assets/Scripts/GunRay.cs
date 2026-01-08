using UnityEngine;
using UnityEngine.InputSystem;

public class GunRay : MonoBehaviour
{
    [Header("Tir")]
    public float range = 15f;

    [Header("Feedback")]
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;

    [Header("Spawn pièce")]
    public GameObject coinPrefab;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
            Shoot();
    }

    void Shoot()
    {
        if (muzzleFlash != null) muzzleFlash.Play();
        if (shootSound != null) shootSound.Play();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Vector3 spawnPos = hit.collider.transform.position;
                Destroy(hit.collider.gameObject);
                Debug.Log("Ennemi tué !");

                if (coinPrefab != null)
                {
                    GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);
                    Coin coinScript = coin.GetComponent<Coin>();
                }
            }
        }
    }
}
