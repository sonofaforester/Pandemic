using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string PendingCity;
    public int PendingMoves = 0;
    public string Name;
    public PlayerRoles Role;

    private Vector3 _targetPosition;
    private float smoothFactor = 2;

    // Start is called before the first frame update
    void Start()
    {
        SetShape();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (PendingMoves > 0)
            GameObject.Find("PlayerName").GetComponent<UnityEngine.UI.Text>().text = "Player: " + Name + " -- " + PendingMoves.ToString() + " moves remaining.";

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * smoothFactor);
    }

    void SetColor()
    {
        var cubeRenderer = this.GetComponentInChildren<Renderer>();

        var color = Role switch
        {
            PlayerRoles.ContingencyPlanner => new Color(0.242f, 0.754f, 0.777f),
            PlayerRoles.Dispatcher => new Color(0.840f, 0.498f, 0.715f),
            PlayerRoles.Medic => new Color(0.984f, 0.498f, 0.203f),
            PlayerRoles.OperationsExpert => new Color(0.512f, 0.761f, 0.344f),
            PlayerRoles.QuarantineSpecialist => new Color(0.098f, 0.465f, 0.358f),
            PlayerRoles.Researcher => new Color(0.602f, 0.406f, 0.297f),
            PlayerRoles.Scientist => new Color(0.789f, 0.824f, 0.816f),
            _ => Color.red
        };

        cubeRenderer.material.SetColor("_Color", color);
    }

    void SetShape()
    {
        var playerObject = GameObject.Find(Role.ToString());

        Debug.Log(Role.ToString());
        Debug.Log(playerObject);

        playerObject.transform.parent = transform;
    }

    private City _currentCity;

    public City CurrentCity
    {
        get
        {
            return _currentCity;
        }
        set
        {
            if (value == null)
                throw new Exception("CurrentCity cannot be null");

            //Initialize starting position without animation
            if (_currentCity == null)
                transform.position = value.gameObject.transform.position;

            _currentCity = value;
            _targetPosition = _currentCity.transform.position;
        }
    }

    public void GoToCity(City city)
    {
        if (city.name == CurrentCity.name)
            return;

        if (!CurrentCity.ConnectedCities.Contains(city))
        {
            Debug.Log("Invalid move to " + city.name);
            throw new Exception("Invalid move");
        }

        if (PendingMoves > 0)
        {
            CurrentCity = city;
            PendingMoves--;
        }
    }

    public void StartTurn()
    {
        PendingMoves = 4;
    }

    public void EndTurn()
    {

    }
}
