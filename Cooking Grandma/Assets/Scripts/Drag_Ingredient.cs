using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Ingredient : MonoBehaviour
{
    Rigidbody2D ingredientRigidBody;
    Collider2D col;

    private void Awake()
    {
      ingredientRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
      col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      /*
      if(Input.touchCount > 0)
      {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

        if(touch.phase == TouchPhase.Began)
        {
          Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
          if(col == touchedCollider)
          {
            moveAllowed = true;
          }
        }

        if(touch.phase == TouchPhase.Moved)
        {
          if(moveAllowed)
          {
            transform.position = new Vector2(touchPosition.x, touchPosition.y);
          }
        }

        if(touch.phase == TouchPhase.Ended)
        {
          moveAllowed = false;
        }
      }
      */
    }

    private void FixedUpdate()
    {
      TouchMove();
    }

    void TouchMove()
    {
      if(Input.GetMouseButton(0)) // equivalent to touch
      {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
        if(col == touchedCollider)
        {
          ingredientRigidBody.transform.position = new Vector2(touchPosition.x, touchPosition.y);
        }
      }
      else // user is not clicking on screen
      {
        ingredientRigidBody.velocity = Vector2.zero;
      }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Combiner"))
      {
        GameObject.Find("RecipeManager").GetComponent<RecipeManager>().IngredientAdded();
        Destroy(gameObject);
      }
    }
}
