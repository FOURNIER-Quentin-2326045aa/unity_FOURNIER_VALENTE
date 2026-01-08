using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] Vector3 m_AngleSpeed;
    [SerializeField] Space m_Space;
    [SerializeField] bool m_Randomize;
    [SerializeField] public int valeur = 10;

    [SerializeField] AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Randomize) transform.Rotate(m_AngleSpeed * Random.Range(0, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_AngleSpeed * Time.deltaTime, m_Space);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.ajouterArgent(valeur);
            }

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
            }

            Destroy(gameObject);
        }
    }


}
