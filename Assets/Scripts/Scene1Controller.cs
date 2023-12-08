using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene1Controller : MonoBehaviour
{
    public Transform redCube;
    public Transform greenCube;
    public GameObject sphereParent;
    public Text distanceText;

    void Start()
    {
        //instantiate cubes and spheres here
    }

    
    void Update()
    {
        //implement cube movement based on keyboard input

        //update distance text
        float distance = Vector3.Distance(redCube.position, greenCube.position);
        distanceText.text = $"Distance: {distance:F2} meters";

        //check distance conditions and show/hide spheres
        if(distance < 2f) {
            ShowSpheres();
        }
        else {
            HideSpheres();
        }

        // check distance condition to scene 2
        if(distance < 1f) {
            LoadScene2();
        }
    }

    private void ShowSpheres(){
        sphereParent.SetActive(true);
    }

    private void HideSpheres(){
        sphereParent.SetActive(false);
        
    }

    private void LoadScene2(){
        SceneManager.LoadScene(1);
    }
}
