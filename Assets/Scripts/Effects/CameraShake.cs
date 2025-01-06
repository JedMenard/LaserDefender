using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float duration = 1;

    [SerializeField]
    private float magnitude = 0.5f;

    private Vector3 initialPosition;

    private void Start()
    {
        this.initialPosition = this.transform.position;
    }

    public void Play()
    {
        this.StartCoroutine(this.Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0;

        while (elapsedTime < this.duration)
        {
            this.transform.position = this.initialPosition + (Vector3)Random.insideUnitCircle * this.magnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        this.transform.position = this.initialPosition;
    }
}
