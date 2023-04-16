
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdemyT3.Combats;
using UdemyT3.Controllers;
using UnityEngine;

namespace UdemyT3.Managers
{
    public class CheckPointManager : MonoBehaviour
    {
        Health _health;
        [SerializeField]
        CheckPointController[] _checkPointControllers;

        private void Awake()
        {
            _checkPointControllers = GetComponentsInChildren<CheckPointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        
        }

        private void Start()
        {
            _health.OnhealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth)
        {
            _health.transform.position = _checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;
            
        }
    }
}