using TMPro;
using UnityEngine;

namespace UI.InGame
{
    public class ActualAmmoText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Start()
        {
            text = GetComponent<TMP_Text>();
        }
        
        private void Update()
        {
            text.text = GameManager.gameManager.Ammos.ToString();
        }
    }
}