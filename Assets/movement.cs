using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Vector3 targetposition;
    public float movementspeed = 5f;
    public GameObject target;
    public float a;
    public float b;
    
    SpriteRenderer sr;
    
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();

       
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

       
        transform.localScale = new Vector3(worldScreenWidth / sr.sprite.bounds.size.x/10, worldScreenHeight / sr.sprite.bounds.size.y/10, 1);
        Debug.Log("worldScreenHeight " + worldScreenHeight);
        Debug.Log("worldScreenW" + worldScreenWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            targetposition = (new Vector3(Random.Range(-a, a), Random.Range(-b, b), 0f));

            target.transform.position = targetposition;

        }
        transform.up = targetposition - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementspeed * Time.deltaTime);
    }
}
