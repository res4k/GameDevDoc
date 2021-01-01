using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask BlockingLayer;
    public float restartLevelDelay = 1f;    

    float h;
    float v;

    private float radius = .3f;
    private Vector2 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        prevPos = movePoint.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if(Mathf.Abs(h) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(h, 0f, 0f), radius, BlockingLayer)) {
                        movePoint.position += new Vector3(h, 0f, 0f);
                }
            } else if (Mathf.Abs(v) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, v, 0f), radius, BlockingLayer)) {
                    movePoint.position += new Vector3(0f, v, 0f);
                }
            }
            
        }
        prevPos = movePoint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Exit"){
            Invoke("Restart", restartLevelDelay);
            GameController.instance.level++;
        }
    }

     private void Restart(){
        GameController.instance.InitGame();
    }
}
