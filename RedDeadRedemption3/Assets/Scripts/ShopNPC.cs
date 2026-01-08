using UnityEngine;
using TMPro;

public class ShopNPC : MonoBehaviour
{
    [Header("Shop settings")]
    public int keyCost = 100;
    public float interactionDistance = 0.2f;
    public TMP_Text interactionText;

    private PlayerInventory playerInventory;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= interactionDistance)
            {
                playerInventory = player.GetComponent<PlayerInventory>();

                if (interactionText != null)
                    interactionText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E) && playerInventory != null)
                {
                    if (playerInventory.argent >= keyCost)
                    {
                        playerInventory.argent -= keyCost;
                        playerInventory.ajouterCle();
                        interactionText.text = "Voici votre clé !";
                    }
                    else
                    {
                        interactionText.text = "Il vous faut 100$ !";
                    }
                }
            }
            else
            {
                playerInventory = null;

                if (interactionText != null)
                    interactionText.enabled = false;
            }
        }
    }
}
