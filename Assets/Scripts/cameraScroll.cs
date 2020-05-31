using UnityEngine;

public class cameraScroll : MonoBehaviour
{

    // Update is called once per frame
    void Update() {
		transform.Translate(Vector3.up * (Input.mouseScrollDelta.y * -0.1f), Space.World);
	}
}
