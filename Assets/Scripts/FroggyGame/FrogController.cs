using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{

    [SerializeField]
    private float jumpSped;
    [SerializeField]
    private Sprite frogHoppinSprite, frogSittinSprite;
    private SpriteRenderer frogRenderer;
    private bool sittin;
    private float hopErp;
    private Vector2 targetPos, prevPos;

    private void Start()
    {

        sittin = true;
        prevPos = transform.position;

    }

    private void Update()
    {

        if(sittin && Input.GetMouseButtonDown(0))
        {

            UnSittinHard();

        }

    }

    private void FixedUpdate()
    {

        if(!sittin)
        {

            hopErp += Time.deltaTime * jumpSped;
            transform.position = Vector2.Lerp(prevPos, targetPos, hopErp);

        }

    }

    public void SittinHard(Vector2 _newTarget)
    {

        prevPos = targetPos;
        targetPos = _newTarget;
        sittin = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = frogSittinSprite;

    }

    public void UnSittinHard()
    {

        sittin = false;
        hopErp = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = frogHoppinSprite;

    }

}
