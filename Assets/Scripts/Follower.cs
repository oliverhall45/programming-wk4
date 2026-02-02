using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    public float turnSpeed = 240f;
    public AudioClip inRangeClip;

    void Update()
    {
        Vector3 direction = SteeringUtility.Seek(transform.position, target.position);
        Move(direction);

        if(Vector3.Distance(transform.position, target.position) < 5)
        {
            AudioManager.Instance.PlayOneShot(inRangeClip);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = transform.position + Time.deltaTime * moveSpeed * direction;

        Quaternion desiredRotation = Quaternion.LookRotation(direction);
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);

        transform.SetPositionAndRotation(newPosition, newRotation);
    }
}
