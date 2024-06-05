using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask groundPlayer;
    public bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();

    }

    public void Check() {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,checkRaduis,groundPlayer);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
        
    }




}
