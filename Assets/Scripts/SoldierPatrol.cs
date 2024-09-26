using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoldierPatrol : MonoBehaviour
{
    public float speed = 1;
    public bool isEnd = true;
    public GameObject failedPanel;
    public GameObject AmbianceSound;
    public GameObject Rain;

    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private GameObject LHLantern;
    [SerializeField] private GameObject RHLantern;

    int index = 0;
    int dir;

    void Start()
    {
         if (SceneManager.GetActiveScene().buildIndex != 2)
         {
             LHLantern.SetActive(false);
             RHLantern.SetActive(false);
         }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenWps();
        LookTowards();
    }

    void LookTowards()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + new Vector3(0, 1.75f, 0), transform.TransformDirection(Vector3.left) * dir);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                StartCoroutine(ReplayAfterFailed());
            }
        }
    }

    void MoveBetweenWps()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPosition;
        transform.LookAt(waypoints[index].transform);

        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
                dir = 1;
                LHLantern.SetActive(true);
                RHLantern.SetActive(false);
            }
            else
            {
                if (isEnd)
                {
                    index = 0;
                    dir = -1;
                    RHLantern.SetActive(true);
                    LHLantern.SetActive(false);
                    
                }
            }

        }
    }

    IEnumerator ReplayAfterFailed()
    {
        AmbianceSound.SetActive(false);
        Rain.SetActive(false);
        failedPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
