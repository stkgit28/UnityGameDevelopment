
using UnityEngine;
using UnityEngine.UI;

public class Healthbar_Lvl6 : MonoBehaviour
{
    
    [SerializeField] private Health_Lvl6 playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start() {
        
        totalhealthBar.fillAmount=playerHealth.currentHealth/10;
    }

    private void Update() {
        currenthealthBar.fillAmount=playerHealth.currentHealth/10;
    }


}
