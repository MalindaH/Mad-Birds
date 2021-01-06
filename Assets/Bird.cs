using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour // base class
{
    //// Start is called before the first frame update
    //void Start(){}

    // by default private (_xxx)
    private Vector3 _initialPosition;
    private bool _birdWasLaunched; // default false
    private float _timeSittingAround;

    // can change value in Unity
    [SerializeField] private float _launchPower = 300;

    private void Awake() // Awake() (before Start()) and Start() at the beginning
    {
        _initialPosition = transform.position;
        // Debug.Log("initial position: "+_initialPosition);
    }

    // Update is called once per frame
    private void Update() 
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if(_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) {
            _timeSittingAround += Time.deltaTime; // 1/framespersecond
        }

        if (transform.position.y > 10 || transform.position.y < -10 || 
            transform.position.x > 20 || transform.position.x < -20 ||
            _timeSittingAround > 2) {
            // reload the scene
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

    
}




