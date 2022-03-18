using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveman_NPC : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    private Vector3 directionVector;
    private Transform transform;
    private Animator animator;
    private Bounds bounds;
    private float decisionTimeCount;
    public float speed;
    public Transform areaBounds;
    public Vector2 decisionTime = new Vector2(1, 4);
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        bounds = new Bounds(areaBounds.position, areaBounds.localScale);
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        Vector3 temp = transform.position + directionVector * speed * Time.deltaTime;
        
        if (bounds.Contains(temp) && decisionTimeCount > 0) {
           decisionTimeCount -= Time.deltaTime;
           rigidBody.MovePosition(temp);
        } else {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        int direction = Random.Range(0,4);
        switch(direction)
        {
            case 0:
                directionVector = Vector3.down;
                break;
            case 1:
                directionVector = Vector3.left;
                break;
            case 2:
                directionVector = Vector3.up;
                break;
            case 3:
                directionVector = Vector3.right;
                break;
            default:
                break;
        }
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        UpdateAnimation();
    }

    void UpdateAnimation() {
        animator.SetFloat("moveX", directionVector.x);
        animator.SetFloat("moveY", directionVector.y);
    }
}
