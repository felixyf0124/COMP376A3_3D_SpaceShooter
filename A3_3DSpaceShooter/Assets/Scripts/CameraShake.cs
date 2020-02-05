using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Transform CamPos;
    public PlayVCamera pCam;
    public Transform player;
    public float duration;

    public float amplitude;


    public IEnumerator CShake()
    {
        Vector3 offset = pCam.Offset;
        float tCounter = 0.0f;
        while (tCounter < duration)
        {
            
            float x = player.position.x + offset.x + Random.Range(-1.0f, 1.0f) * amplitude;
            float y = player.position.y + offset.y + Random.Range(-1.0f, 1.0f) * amplitude;

            transform.position = new Vector3(x, y, player.position.z + offset.z);
            tCounter += Time.deltaTime;

            yield return null;

        }

        CamPos.position = player.position + offset;

    }
}
