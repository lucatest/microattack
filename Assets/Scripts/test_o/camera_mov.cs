using UnityEngine;
using System.Collections;

public class camera_mov : MonoBehaviour {
	
	public float offset_x;
	public float offset_y;
	public float offset_z;
	public float offset_posY;

	public Transform target;

	Vector3 cam_pos;

	float cam_z, cam_x, cam_y;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cam_pos = target.position;
		transform.position = target.position + new Vector3 (offset_x, offset_y, offset_z);
		//transform.position = target.position - new Vector3 (offset_x, offset_y, 0);
		transform.LookAt (target);
		//Vector3 cam_pos = transform.position;
		//transform.position = new Vector3 (cam_pos.x, cam_pos.y + offset_posY, cam_pos.z);

		/*


		transform.position.z =  target.position.z;
		transform.position.x =  target.position.x -offset_x;
		transform.position.y =  target.position.y -offset_y;
		transform.LookAt(target);
		transform.position.y =  target.position.y +offset_posY;
		camera.fieldOfView = 46;
		*/
	}


}