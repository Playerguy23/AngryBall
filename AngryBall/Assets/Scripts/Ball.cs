using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D hook;
    public float releasTime = 0.15f;
    public float maxDragingDistance = 2;

    private Rigidbody2D rb;
    private bool isPressed = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(isPressed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mousePosition, hook.position) > maxDragingDistance) {
                rb.position = hook.position + (mousePosition - hook.position).normalized * maxDragingDistance;
            }else {
                rb.position = mousePosition;
            }
        }
    }

    void OnMouseDown() {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release() {
        yield return new WaitForSeconds(releasTime);

        GetComponent<SpringJoint2D>().enabled = false;
        enabled = false;
    }
}
