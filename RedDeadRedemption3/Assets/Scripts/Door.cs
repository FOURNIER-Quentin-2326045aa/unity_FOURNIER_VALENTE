using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [Header("Réglages")]
    public float interactionDistance = 3f;
    public float openAngle = 90f;
    public float openSpeed = 2f;

    [Header("Texte")]
    public TMP_Text interactionText;

    private GameObject player;
    private PlayerInventory inventory;

    private bool isOpening = false;
    private bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();

        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y + openAngle,
            transform.eulerAngles.z
        );

        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player == null || inventory == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactionDistance && !isOpen)
        {
            interactionText.gameObject.SetActive(true);

            if (inventory.cles > 0)
                interactionText.text = "Appuyez sur E pour ouvrir";
            else
                interactionText.text = "Vous avez besoin d'une clé !";

            if (Input.GetKeyDown(KeyCode.E) && inventory.cles > 0)
            {
                inventory.cles--;
                isOpening = true;
                isOpen = true;
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }

        if (isOpening)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                openRotation,
                Time.deltaTime * openSpeed
            );
        }
    }
}
