using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiInimigo : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody2D rb;
    private Vector3 direcaoInicial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direcaoInicial = (Random.Range(1, 10) % 2 == 0) ? Vector3.left : Vector3.right;
    }

    private void FixedUpdate()
    {
        rb.transform.position += direcaoInicial * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LevelBorder")
            Destroy(rb.gameObject);

        direcaoInicial = ( Random.Range(1, 10) % 2 == 0 ) ? Vector3.left : Vector3.right; 
    }

}
