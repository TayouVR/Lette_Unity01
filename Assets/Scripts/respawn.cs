using UnityEngine;

public class Respawn : MonoBehaviour {

	public float respawnHeight = -5;
	public float heightToRespawnTo = 2;

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y <= respawnHeight)
        {
	        var position = transform.position;
	        transform.SetPositionAndRotation(new Vector3(position.x > 20 ? 19 : position.x, heightToRespawnTo, position.z > 20 ? 19 : position.z), transform.rotation);
        }
    }
}
