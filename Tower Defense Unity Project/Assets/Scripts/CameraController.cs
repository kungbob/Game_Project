using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;

	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;

    public float rotateSpeed = 20f;


    // Update is called once per frame
    void Update () {

		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey("up"))
		{
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey("down"))
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey("right"))
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey("left"))
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

        if (Input.GetKey(KeyCode.Keypad7) )
        {
            transform.Rotate(0, - rotateSpeed * Time.deltaTime, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.Keypad9))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;

	}
}
