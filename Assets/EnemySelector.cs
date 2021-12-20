using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("I swear i'm working");
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.CircleCast(
                    origin: mouseWorldPos,
                    radius: 0.01f,
                    direction: new Vector2(0, 0),
                    distance: 0.01f);
            if(hit.collider is not null)
            {
                hit.transform
                        .GetComponentInParent<Enemy>()
                        .GetAttacked();
            }
        }
    }
}
