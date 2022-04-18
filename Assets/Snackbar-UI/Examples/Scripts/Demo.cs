using DigvijaysinhG.SnackBarUtility;
using TMPro;
using UnityEngine;

public class Demo : MonoBehaviour {
    [SerializeField] private TMP_InputField inputField;

    public void ShowSnackBar() {
        if(string.IsNullOrEmpty(inputField.text))
            return;
        
        SnackBar.Show(inputField.text);
    }
}
