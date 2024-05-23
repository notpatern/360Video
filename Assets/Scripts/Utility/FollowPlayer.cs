
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameEventScriptableObject _playerTransform;
    [SerializeField] float lerpSpeed;
    Transform playerTransform;

    private void Awake() {
        _playerTransform.BindEventAction(LoadPlayerTransform);
    }

    private void LoadPlayerTransform(object obj) {
        playerTransform = obj as Transform;
    }

    void Update() {
        Vector3 direction = playerTransform.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), lerpSpeed * Time.deltaTime);
    }
}
