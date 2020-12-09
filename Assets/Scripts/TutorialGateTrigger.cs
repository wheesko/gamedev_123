﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TutorialManager.Instance.EndTutorial();
        }
    }
}
