using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float ShakeTime = 1f;
    [SerializeField] float shakeMagnitude;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed =0;
        while(timeElapsed<ShakeTime)
        {
           transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
           timeElapsed += Time.deltaTime;
           yield return new WaitForEndOfFrame();
        }   
        transform.position = initialPosition;     
    }

    
}
