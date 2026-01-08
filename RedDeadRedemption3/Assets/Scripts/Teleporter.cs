using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tentative de téléportation...");

            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                Debug.Log("Désactivation du CharacterController...");
                controller.enabled = false;
                other.transform.position = destination.position + Vector3.up * 0.5f;
                controller.enabled = true;
                Debug.Log("CharacterController réactivé");
            }
            else
            {
                other.transform.position = destination.position + Vector3.up * 0.5f;
            }

            Debug.Log($"Nouvelle position: {other.transform.position}");
        }
    }
}