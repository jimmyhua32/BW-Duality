using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    public AudioSource explosion;
    public AudioSource flip;

    private float magnitude = 0.7f;
    private float duration = 0f;
    private float decayspeed = 1.5f;
    private Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
       position = transform.localPosition;
    }

    // Update is called once per fixed interval
    void Update()
    {
        if (duration > 0)
        {
            Vector2 newPos = position + Random.insideUnitSphere * magnitude;
            transform.localPosition = new Vector3(newPos.x, newPos.y, position.z);
            duration -= Time.deltaTime * decayspeed;
        }
        else
        {
            duration = 0;
            transform.localPosition = position;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TriggerShake(float duration, float magnitude)
    {
        this.duration = duration;
        this.magnitude = magnitude;
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }

    public void PlayFlip()
    {
        flip.Play();
    }
}
