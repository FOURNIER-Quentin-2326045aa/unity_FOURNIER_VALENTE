using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int argent = 0;
    public int cles = 0;

    public void ajouterArgent(int montant)
    {
        argent += montant;
    }

    public void ajouterCle()
    {
        cles += 1;
    }
}
