using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShower : MonoBehaviour
{

    [SerializeField] private GameObject title1;
    [SerializeField] private GameObject title2;
    [SerializeField] private GameObject title3;
    [SerializeField] private GameObject title4;
    [SerializeField] private float startDelay;
    [SerializeField] private float title1Duration;
    [SerializeField] private float title2Duration;
    [SerializeField] private float title3Duration;
    [SerializeField] private float title4Duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoTitlesSequence());
    }

    private IEnumerator DoTitlesSequence()
    {
        yield return new WaitForSeconds(startDelay);
        title1.SetActive(true);
        title2.SetActive(false);
        title3.SetActive(false);
        title4.SetActive(false);
        yield return new WaitForSeconds(title1Duration);
        
        
        title1.SetActive(false);
        title2.SetActive(true);
        title3.SetActive(false);
        title4.SetActive(false);
        yield return new WaitForSeconds(title2Duration);
        
        title1.SetActive(false);
        title2.SetActive(false);
        title3.SetActive(true);
        title4.SetActive(false);
        yield return new WaitForSeconds(title1Duration);
        
        title1.SetActive(false);
        title2.SetActive(false);
        title3.SetActive(false);
        title4.SetActive(true);
        yield return new WaitForSeconds(title1Duration);
        
        
        title1.SetActive(false);
        title2.SetActive(false);
        title3.SetActive(false);
        title4.SetActive(false);
    }
    
    
}
