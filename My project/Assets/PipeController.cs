using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private float pipeSpeed;
    void Update()
    {
        transform.position += new Vector3(-0.1f,0,0) * pipeSpeed * Time.deltaTime;
    }
}
