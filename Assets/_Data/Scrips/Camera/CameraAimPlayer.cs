using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraAimPlayer : MMonoBehaviour
{
    public Transform player; // Nhân vật mà camera sẽ theo dõi
    public Vector3 offset = new Vector3(0, 5, -10); // Khoảng cách mặc định từ camera đến nhân vật

    public float sensitivity = 2f; // Độ nhạy khi xoay camera
    public float zoomSpeed = 5f;   // Tốc độ zoom
    public float minZoom = 2f;     // Giới hạn zoom gần
    public float maxZoom = 20f;    // Giới hạn zoom xa

    private float currentZoom = 10f; // Khoảng cách zoom hiện tại
    private float pitch = 2f;        // Góc nâng camera theo trục Y
    private float yaw = 0f;          // Góc xoay camera theo trục X

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        // Zoom in/out bằng cuộn chuột
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Xoay camera bằng chuột phải
        if (Input.GetMouseButton(1)) // Chuột phải
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;

            // Giới hạn góc pitch (tránh camera nhìn từ dưới lên quá nhiều)
            pitch = Mathf.Clamp(pitch, 0f, 45f);
        }
    }

    void LateUpdate()
    {
        // Đặt vị trí camera dựa trên vị trí nhân vật
        Vector3 direction = new Vector3(0, 0, -currentZoom);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        transform.position = player.position + rotation * offset + rotation * direction;
        transform.LookAt(player.position + Vector3.up * 2f); // Nhìn lên một chút để trung tâm là nhân vật
    }
}
