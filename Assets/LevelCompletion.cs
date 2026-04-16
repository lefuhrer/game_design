using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    public enum Level{
        Level1,
        Level2,
        Credits
    }

    [SerializeField]
    private Transform red;
    [SerializeField]
    private Transform green;
    [SerializeField]
    private Transform blue;
    [SerializeField]
    private float range = 5f;

    [SerializeField]
    private Level nextLevel;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(red.position, blue.position) < range && Vector3.Distance(red.position, green.position) < range)
        {
            SceneManager.LoadScene(nextLevel.ToString());
        }

    }
}
