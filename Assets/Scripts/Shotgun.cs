using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int perdigons;
    [SerializeField] private float distance;

    private void Start()
    {
    }

    private void Update()
    {
        Handle();
    }

    private void Handle()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        for (int i = 0; i < perdigons; i++)
        {
            Vector3 point = (transform.forward * distance) + Random.insideUnitSphere * radius;

            if (Physics.Linecast(transform.position, point, out RaycastHit hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green, 0.5f);
                Debug.Log($"Collision whit object: [{hit.collider.name}]");
            }
            else
            {
                Debug.DrawLine(transform.position, point, Color.red, 0.5f);
                Debug.Log($"Collision whit point: [{point}]");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.forward * distance, radius);
    }
}