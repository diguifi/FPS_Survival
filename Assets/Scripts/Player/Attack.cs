using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 5f;
    public float radius = 1f;
    public LayerMask layerMask;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (hits.Any())
        {
            hits.FirstOrDefault().GetComponent<Health>().DealDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
