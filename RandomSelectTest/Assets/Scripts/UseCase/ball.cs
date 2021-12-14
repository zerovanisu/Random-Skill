using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 5f;        //player Speed
    private float horizontalInput;  // player move
    private float forwardInput;     // input forward

    public bool isBoostedActived = false;  // boostspeed bool
    [SerializeField]
    private float BoostTime = 10.0f;   // boost Time
    [SerializeField] 
    private float BoostIncrease = 10.0f;  //boost Speed
    

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    
    private void OnCollisionEnter(Collision hit)
    {
        switch(hit.gameObject.tag)
        {
            case "BallSpeed":
            if(isBoostedActived)
            {
                speed = speed * BoostIncrease;
            }
            //else
            //{
            //    speed = speed * 1.0f;
            //}
            if(!isBoostedActived)
            {
                isBoostedActived = true;
                Invoke("EndBoost", BoostTime);
            }
            //speed = 20f;
            //Destroy(gameObject,10);
            break;

            case "Multiple":
            Destroy(hit.gameObject);
            Instantiate(this.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject,10);
            break;

            //この所あまり出来てない
            case"TimeSpeed":
            Debug.Log("Hit");
            TimeControl.moveTime();
            break;
        }
    }
    private void EndBoost()
    {
        isBoostedActived = false;
    }
}

