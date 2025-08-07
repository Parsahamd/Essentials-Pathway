using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Real-time seconds it takes for a full in-game day to pass.")]
    [SerializeField] private float dayDurationInSeconds = 60f;

    private float rotationSpeed;

    void Start()
    {
        // 360 degrees over the duration of a day
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    void Update()
    {
        // Rotate around the X-axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}