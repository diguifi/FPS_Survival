using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    bool hasCollided = false;
    Transform player;

    void Update()
    {
        if (hasCollided)
        {
            var distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
                Interact();
        }
    }

    public void HasCollided(Transform playerTransofrm)
    {
        player = playerTransofrm;
        hasCollided = true;
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
