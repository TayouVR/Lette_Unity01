using UnityEngine;

public class EnemyViewCone : MonoBehaviour {
    
    public Enemy enemyScript;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("Player")) {
            enemyScript.SetGoal(other.gameObject);
        }
    }
}
