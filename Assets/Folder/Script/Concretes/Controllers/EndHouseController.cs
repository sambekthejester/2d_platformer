using System.Collections;
using System.Collections.Generic;
using UdemyT3.Managers;
using UnityEngine;

namespace UdemyT3.Controllers {
    public class EndHouseController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player!=null)
            {
                GameManager.Instance.LoadMenuAndUi(2f);
            }
        }





    }


}
