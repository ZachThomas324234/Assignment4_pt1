using UnityEngine;

public class KarlsonCamera : MonoBehaviour {

    public Transform player;

    void Update() {
        transform.position = player.transform.position;
    }
}