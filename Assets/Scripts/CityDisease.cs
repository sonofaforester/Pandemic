using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CityDisease : MonoBehaviour
{
    private Disease _disease = null;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_disease == null)
            gameObject.SetActive(false);
        else
        {
            gameObject.SetActive(true);

            gameObject.GetComponent<Image>().color = _disease.Region.GetColor();
        }
    }

    public void SetDisease(Disease disease)
    {
        if (_disease != null)
            throw new Exception("Adding disease to existing disease");

        _disease = disease;
    }

    public void HealDisease()
    {
        _disease = null;
    }
}
