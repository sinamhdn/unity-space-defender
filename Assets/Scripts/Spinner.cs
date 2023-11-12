using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinningSpeed * Time.deltaTime);
    }
}
