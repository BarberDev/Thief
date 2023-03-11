using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{

    public Transform movePosition;
    public Transform runPosition;
    float moveSpeed = 1;
 

    void Start()
    {
         
    }

     
    void Update()
    {
        Move(movePosition);
    }

    void Move(Transform pos) 
    {
        transform.position = Vector2.MoveTowards(transform.position,pos.position, moveSpeed * Time.deltaTime);
    }

    public void ChangePosition() 
    {       
        StartCoroutine(waite());      
    }

    IEnumerator waite() 
    {
        yield return new WaitForSeconds(1);
        movePosition = runPosition;
        SpriteRenderer[] spritesRenderer = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < spritesRenderer.Length; i++)
        {
            spritesRenderer[i].flipX = true;
        }
        moveSpeed = 2;
    }
}
