using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bird : MonoBehaviour
{
    [SerializeField] private GameObject nextBird;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D hook;
    private bool isPressed = false;
    private float releaseTime = 0.15f;
    private float maxDragDistance = 2f;

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true; 
    }

    void OnMouseUp()
    {
        isPressed = false; 
        rb.isKinematic = false; 
        StartCoroutine(Release()); 
    }

    private void Update() 
    {
        if (isPressed) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            if (Vector2.Distance(mousePos, hook.position) > maxDragDistance) 
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance; 
            }
            else 
            {
                rb.position = mousePos;
            }
        }
    }

    IEnumerator Release() 
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false; 
        yield return new WaitForSeconds(2f); 
        if (nextBird != null)
        {
            nextBird.SetActive(true); 
        }
        else 
        {
            Pig.enemiesAlive = 0; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}
