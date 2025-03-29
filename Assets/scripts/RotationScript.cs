using UnityEngine;

public class RotationScript : MonoBehaviour{

    public float rotateSpeed = 180.0f;
    void Start()    {        
    }
    void Update()    {
        transform.Rotate(rotateSpeed * Vector3.up * Time.deltaTime);
    }
}
