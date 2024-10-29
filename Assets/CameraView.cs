using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;  // Velocidade de movimento da câmera
    public float rotationSpeed = 100f;  // Velocidade de rotação da câmera
    public float zoomSpeed = 10f;  // Velocidade do zoom

    void Update()
    {
        // Movimento com WASD
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Teclas A e D
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // Teclas W e S

        // Mover a câmera
        transform.Translate(moveX, 0, moveZ);

        // Rotação com o botão direito do mouse
        if (Input.GetMouseButton(1))  // Botão direito do mouse
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Girar a câmera ao redor do eixo Y (horizontal)
            transform.Rotate(0, rotX, 0, Space.World);

            // Inclinar a câmera para cima e para baixo (vertical)
            transform.Rotate(-rotY, 0, 0, Space.Self);
        }

        // Zoom da câmera com a roda do mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        transform.Translate(0, 0, scroll);
    }
}
