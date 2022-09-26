using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    
    public float delay = 0.1f;
    public float longDelay = 0.3f;
    public string welcomeText;
    public string missionText;
    public string signOffText;
    public new AudioSource audio;
    private string currentText = "";
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText() {
        yield return new WaitForSeconds(3);
        audio.Play();
        for (int i = 0; i < welcomeText.Length; i++) {
            currentText = welcomeText.Substring(0,i);
            this.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        audio.Stop();
        yield return new WaitForSeconds(longDelay);
        audio.Play();
        for (int j = 0; j < missionText.Length; j++) {
            currentText = welcomeText + "\n\n" + missionText.Substring(0, j);
            this.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        audio.Stop();
        yield return new WaitForSeconds(longDelay);
        audio.Play();
        for (int k = 0; k < signOffText.Length; k++) {
            currentText = welcomeText + "\n\n" + missionText + "\n\n" + signOffText.Substring(0, k);
            this.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        audio.Stop();
    }

}
