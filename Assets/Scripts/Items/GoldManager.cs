namespace Items
{
    using UnityEngine;
    using TMPro;

    public class GoldManager : MonoBehaviour
    {
        public TMP_Text goldText;
        public int gold;

        private void Start()
        {
            goldText.text = gold.ToString();
        }

        // Update is called once per frame
        private void Update()
        {
            goldText.text = gold.ToString();
        }
    }
}