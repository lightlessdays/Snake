using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D gridArea;


    void Start()
    {
        randomizePosition();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.tag=="Player") randomizePosition();
    }

    void randomizePosition() {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y));
    }


}
