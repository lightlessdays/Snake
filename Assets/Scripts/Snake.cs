using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    [SerializeField] private Transform snakeBody;
    [SerializeField] private GameObject gameManager;
    private Vector2 previousDirection;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&&_direction!=Vector2.down) {
            previousDirection = _direction;
            _direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _direction != Vector2.right)
        {
            previousDirection = _direction;
            _direction = Vector2.left;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && _direction != Vector2.up)
        {
            previousDirection = _direction;
            _direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _direction != Vector2.left)
        {
            previousDirection = _direction;
            _direction = Vector2.right;
        }
    }
  
    private void FixedUpdate()
    {
        for (int i = _segments.Count-1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0
            );
    }

    private void Grow() {
        Transform segment = Instantiate(snakeBody);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            gameManager.GetComponent<GameManager>().IncreaseScore();
        }

        else if (collision.tag == "Wall")
        {
            Death();
        }

        else if (collision.tag == "Body") {
            if (previousDirection * -1 != _direction) Death();
        }
    }

    private void Death() {
        gameManager.GetComponent<GameManager>().KillSnake();
    }
}
