using UnityEngine;

public class movingwall : MonoBehaviour
{

    public float moveDistance = 3f;  
    public float moveSpeed = 2f;     

    private Vector3 startPos;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false; 
        }
        else 
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true; 
        }
    }
}

