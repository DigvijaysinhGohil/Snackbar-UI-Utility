using TMPro;
using UnityEngine;

namespace DigvijaysinhG {

    namespace SnackBarUtility {

        public class SnackBarTest : MonoBehaviour {
            [SerializeField] private TMP_InputField inputField;

            public void ShowSnackBar() {
                if (string.IsNullOrEmpty(inputField.text))
                    return;

                SnackBar.Show(inputField.text);
            }
        }

    }

}