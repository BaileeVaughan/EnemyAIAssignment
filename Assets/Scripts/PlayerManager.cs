using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Vector3 moveDir;
    public CharacterController charC;
    public float normalSpeed = 10f, temporarySpeed = 10f;
    public bool isSprint = false;
    public Transform start;

    public GameObject winstate;
    public GameObject danger;

    void Start()
    {
        charC = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        temporarySpeed = normalSpeed;
        isSprint = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            temporarySpeed = 20f;
            normalSpeed = temporarySpeed;
            isSprint = true;
        }
        else
        {
            normalSpeed = 10f;
            isSprint = false;
        }
        moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * normalSpeed);
        charC.Move(moveDir * Time.deltaTime);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Winstate")
        {
            winstate.SetActive(true);
        }
        else
        {
            winstate.SetActive(false);
        }
    }
}