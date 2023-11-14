using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        input.Normalize();
        Debug.Log(input);
        transform.position += speed * Time.deltaTime * input;
    }
}
