using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void FixedUpdate()
    {
        Vector3 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        input.Normalize();
        transform.position += speed * Time.deltaTime * input;
    }
}
