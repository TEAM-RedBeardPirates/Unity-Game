using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    public GameObject[] weapons;
    public bool[] hasWeapon;
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    GameObject nearObject;
    GameObject equipWeapon;
    int equipWeaponIndex = -1;

    bool iDown;
    bool sDown1;
    bool sDown2;

void Start(){
    
}

    void Update(){
        GetInput();
        Move();
        Swap();
        Interation();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);
    }

    void Swap()
    {
        if (sDown1 && (!hasWeapon[0] || equipWeaponIndex == 0))
            return;
        if (sDown2 && (!hasWeapon[1] || equipWeaponIndex == 1))
            return;

        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;

        if (sDown1 || sDown2)
        {
            if (equipWeapon != null)
                equipWeapon.SetActive(false);
            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex];
            equipWeapon.SetActive(true);
        }
    }

    void Interation()
    {
        if(iDown && nearObject != null)
        {
            if(nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasWeapon[weaponIndex] = true;

                Destroy(nearObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
        Debug.Log("æ∆¿Ã≈€ ¥Í¿Ω");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
    }
}
