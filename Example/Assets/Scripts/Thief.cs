using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public Transform movePosition;
    public Transform runPosition;
    private float moveSpeed = 1;    
    private float waitTime = 1;

    private void Update()
    {
        Move(movePosition);
    }
 
    private void Move(Transform pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);
    }

    public void ChangePosition()
    {
        StartCoroutine(waite());
    }

    IEnumerator waite()
    {
        var waite = new WaitForSeconds(waitTime);
        yield return waite;
        movePosition = runPosition;
        SpriteRenderer[] spritesRenderer = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spritesRenderer.Length; i++)
        {
            spritesRenderer[i].flipX = true;
        }
        moveSpeed = 2;
    }
}
