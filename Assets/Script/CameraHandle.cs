
using UnityEngine;
public class CameraHandle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Tốc độ di chuyển của camera
    [SerializeField] private float maxRotationY = 60f; // Góc quay tối đa theo trục Y
    [SerializeField] private float minRotationY = -40f; // Góc quay tối thiểu theo trục Y
    [SerializeField] private float maxRotationX = 90f;
    [SerializeField] private float minRotationX = -90f;


    private bool isDragging = false; // Biến kiểm tra xem chuột có đang được giữ không
    private Vector3 lastMousePosition; // Vị trí chuột cuối cùng

    void Update()
    {
        CameraRolate();
    }

    private void CameraRolate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true; // Bắt đầu kéo nếu người chơi nhấn giữ chuột
            lastMousePosition = Input.mousePosition; // Lưu vị trí chuột cuối cùng
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; // Kết thúc kéo khi người chơi nhả chuột
        }

        if (isDragging)
        {
            // Tính toán sự chuyển động của chuột từ vị trí cuối cùng đến vị trí hiện tại
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            // Tính góc quay theo trục từ sự chuyển động của chuột
            float rotationX = deltaMousePosition.x * moveSpeed * Time.deltaTime;
            float rotationY = deltaMousePosition.y * moveSpeed * Time.deltaTime;

            // Giới hạn góc quay theo trục 
            rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
            rotationX = Mathf.Clamp(rotationX,minRotationX, maxRotationX);
            // Xoay camera
            transform.Rotate(Vector3.left * rotationY * moveSpeed);
            transform.parent.Rotate(Vector3.down * rotationX * moveSpeed);
            // Cập nhật vị trí chuột cuối cùng
            lastMousePosition = Input.mousePosition;
        }
    }

}



