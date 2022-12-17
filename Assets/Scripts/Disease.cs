using Assets.Scripts;
using UnityEngine;

public class Disease : MonoBehaviour
{
    public Region Region;
    public City City { get; private set; }

    private Vector3 _targetPosition;
    private float smoothFactor = 2;
    private Vector3 _pilePosition;

    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * smoothFactor);
    }

    public void SetPilePosition(int position)
    {
        transform.Translate(Vector3.left * (float)(position / .005));
        _targetPosition = transform.position;
    }

    public void SetCity(City city)
    {
        City = city;

        if (city != null)
        {
            if (_pilePosition == null) //record original position
                _pilePosition = transform.position;

            // Debug.Log(city.name + " x:" + city.transform.position.x + " y:" + city.transform.position.y + " z:" + city.transform.position.z);
            _targetPosition = city.transform.position;
            // Debug.Log(name + " x:" + _targetPosition.x + " y:" + _targetPosition.y + " z:" + _targetPosition.z);

        }
        else
        {
            _targetPosition = _pilePosition;
        }
    }

    void SetColor()
    {
        var cubeRenderer = this.GetComponentInChildren<Renderer>();
        cubeRenderer.material.SetColor("_Color", Region.GetColor());
    }
}
