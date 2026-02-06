using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target;   // El jugador
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -6);
    [SerializeField] private float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Posició objectiu de la càmera
        Vector3 desiredPosition = target.position + offset;

        // Moviment suau
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Mira cap al jugador (opcional)
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
