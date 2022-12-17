using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardScript : MonoBehaviour
{
    public PlayerCard Card { get; set; }

    private Text _textBox;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _textBox = gameObject.GetComponentInChildren<UnityEngine.UI.Text>();
        _image = gameObject.GetComponentInChildren<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Card == null)
        {
            _image.GetComponent<Image>().color = Color.gray;
            _textBox.text = "";
            return;
        }

        _textBox.text = Card.City.name;

        Color color;

        switch (Card.City.Region)
        {
            case Region.Blue:
                color = Color.blue;
                break;
            case Region.Yellow:
                color = Color.yellow;
                break;
            case Region.Black:
                color = Color.black;
                break;
            case Region.Red:
                color = Color.red;
                break;
            default:
                color = Color.white;
                break;
        }

        _image.GetComponent<Image>().color = color;
    }
}
