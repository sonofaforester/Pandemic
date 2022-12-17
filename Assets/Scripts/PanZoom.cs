using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 5000;
    public float zoomOutMax = 10000;
    public float zoomSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicky click");
            var pos = Input.mousePosition;
            pos.z = 10000;

            touchStart = Camera.main.ScreenToWorldPoint(pos);
        }
        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
            pos.z = 10000;

            var direction = touchStart - Camera.main.ScreenToWorldPoint(pos);

            Debug.Log(Camera.main.ScreenToWorldPoint(pos));
            Camera.main.transform.position += direction;
        }



        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment)
    {
        var zVal = Mathf.Clamp(Camera.main.transform.position.z - increment * 800, 5000f, 10000f);
        var rVal = Mathf.Clamp(Camera.main.transform.rotation.z - increment / 15, -0.4f, 0f);
        Camera.main.transform.SetPositionAndRotation(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, zVal), new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, rVal, Camera.main.transform.rotation.w));
    }
}
