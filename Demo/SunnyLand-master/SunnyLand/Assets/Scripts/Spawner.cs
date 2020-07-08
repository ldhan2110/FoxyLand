using UnityEngine;
using UnityEngine.Events;

public sealed class Spawner : MonoBehaviour
{
    public GameObject _template;
    public float _spawnTime;

    private float _time;
    private GameObject _obj;

    private void Awake()
    {
        _time = _spawnTime;
    }

    void Update ()
    {
		if(!IsObjectExists() && _time > 0)
        {
            _time -= Time.deltaTime;
        }
        else if (!IsObjectExists())
        {
            CreateCherry();
            _time = _spawnTime;
        }
	}

    private bool IsObjectExists()
    {
        return _obj != null;
    }

    private void CreateCherry()
    {
        _obj = Instantiate(_template, transform.position, transform.rotation);
    }
}
