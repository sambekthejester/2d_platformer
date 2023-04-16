using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyT3.Controllers
{
    public class HiddenRoomController : MonoBehaviour
    {
        [SerializeField] GameObject _ladder;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                if (_ladder.gameObject.activeSelf == true) return;
                _ladder.gameObject.SetActive(true);

            }

        }
    }
}
