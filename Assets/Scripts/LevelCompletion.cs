using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    public enum Level
    {
        TestLevel,
        Credits
    }

    [SerializeField]
    private Transform _red;
    [SerializeField]
    private Transform _green;
    [SerializeField]
    private Transform _blue;

    [SerializeField]
    private float _range = 5f;

    [SerializeField]
    private Level _nextLevel;

    private void Update()
    {
        if ((Vector3.Distance(_red.position, _blue.position) < _range && Vector3.Distance(_red.position, _green.position) < _range) ||
            (Vector3.Distance(_green.position, _blue.position) < _range && Vector3.Distance(_green.position, _red.position) < _range) ||
            (Vector3.Distance(_blue.position, _green.position) < _range && Vector3.Distance(_blue.position, _red.position) < _range))
        {
            SceneManager.LoadScene(_nextLevel.ToString());
        }
    }
}
