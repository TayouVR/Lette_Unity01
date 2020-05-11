using UnityEngine;

public class CollisionDamage : MonoBehaviour {
    
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            other.gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }
}
