using UnityEngine;

public class CollisionDamage : MonoBehaviour {
    
    public float damage;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            other.gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }
}
