using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    [SerializeField] private health playerhealth;
    [SerializeField] private Image Totalhealthbar;
    [SerializeField] private Image Currenthealthbar;

    private void Start()
    {
        Totalhealthbar.fillAmount = playerhealth.currenthealth / 10;
    }
    private void Update()
    {
        Currenthealthbar.fillAmount = playerhealth.currenthealth/10;
    }
}
