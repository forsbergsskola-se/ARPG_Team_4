using UnityEngine;

public class FadeWalls : MonoBehaviour{
    private UnityEngine.Camera mainCamera;
    private GameObject player;
    private GameObject[] walls;
    private Color _color;
    [Range(0.0f, 1.0f)]
    public float alphaValueSlider;
    RaycastHit hitInfo;
    private void Start(){
        mainCamera = UnityEngine.Camera.main;
        player = this.gameObject;
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
    private void Update(){
        var dir = player.transform.position - mainCamera.transform.position;
        if (Physics.Raycast(mainCamera.transform.position, dir, out hitInfo, 1000)){
            foreach (GameObject wall in walls){
                if (hitInfo.collider.gameObject == wall){
                    wall.GetComponent<Renderer>().material.color = new Color(1,1,1,alphaValueSlider);
                }
                else if (hitInfo.collider.gameObject != wall){
                    wall.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
                }
            }
        }
    }
}
