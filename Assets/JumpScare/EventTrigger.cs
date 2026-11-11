using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public EnemyController controller;
    public EnemyController.Events eventToExecute;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (controller != null)
            {
                controller.gameObject.SetActive(true);

                switch (eventToExecute)
                {
                    case EnemyController.Events.AnimIdle:
                        controller.PlayAnimIdle();
                        break;
                    case EnemyController.Events.AnimIdleLoja:
                        controller.PlayAnimIdleLoja();
                        break;
                    case EnemyController.Events.AnimIdleArmazem:
                        controller.PlayAnimIdleArmazem();
                        break;
                }
            }
            gameObject.SetActive(false);
        }
    }
}