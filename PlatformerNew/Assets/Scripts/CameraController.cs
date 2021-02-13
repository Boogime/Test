using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camera;
    public Transform target;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float value = 0.01f;
    private void Update()
    {
        if (Vector2.Distance(camera.position, target.position) > value)
        {
            camera.position = new Vector3(Mathf.Lerp(camera.position.x, target.position.x, speed * Time.deltaTime),
              Mathf.Lerp(camera.position.y, target.position.y, speed * Time.deltaTime), -10);
        }
    }
}

