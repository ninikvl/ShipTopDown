using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTierUpBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GunController gunController = collision.GetComponentInChildren<GunController>();
        if (gunController != null )
            gunController.GunTierUp();

        Destroy(gameObject);
    }
}
