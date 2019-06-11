using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector2 MinChange;
    public Vector2 MaxChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    private Vector2 test = new Vector2 (4,5);
    private Vector2 test2 = new Vector2 (4,5);

    // Start is called before the first frame update
    void Start()
    {
      cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("Player")){
        cam.maxPosition += cameraChange;
        cam.minPosition += cameraChange;
        other.transform.position += playerChange;
        cam.maxPosition = MaxChange;
        cam.minPosition = MinChange;

        PlayerPrefs.SetFloat("CamMinX",cam.minPosition.x);
        PlayerPrefs.SetFloat("CamMaxX",cam.maxPosition.x);

        PlayerPrefs.SetFloat("CamMinY",cam.minPosition.y);
        PlayerPrefs.SetFloat("CamMaxY",cam.maxPosition.y);
      }
    }

  /*  public static void SetCamera(Vector2 MaxPos, Vector2 MinPos){
      cam.maxPosition = MaxPos;
      cam.minPosition = MinPos;

    }*/
}
