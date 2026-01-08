using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 90, 0);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victoire");
        }
    }
}
