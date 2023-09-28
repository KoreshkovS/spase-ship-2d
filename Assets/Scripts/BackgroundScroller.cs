using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidBody;


    private float width;
    private float scrollSpeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        width = _collider.size.x;
        _collider.enabled = false;
        _rigidBody.velocity = new Vector2(scrollSpeed, 0);
        ResetObcacle();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObcacle();
        }
    }

    public void ResetObcacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-3, 3), 0);
    }
}
