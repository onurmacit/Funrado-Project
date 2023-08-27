using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedDoor : MonoBehaviour
{
    public HingeJoint hinge;
    JointMotor motor;
    public float velaocity;
    public float angle;
    public KeyUI keyUI;

     UITween uıTweenScript; 


    void Start()
    {
        motor = hinge.motor;

        uıTweenScript = FindObjectOfType<UITween>();

        hinge.useMotor = false;
        hinge.useLimits = false;
        hinge.useSpring = false;
        hinge.useMotor = false;
        hinge.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        keyUI = FindObjectOfType<KeyUI>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("RedCube") && keyUI.redKey.gameObject.activeSelf)
        {
            Color redKeyColor = keyUI.redKey.color;
            redKeyColor.a = 0f;
            keyUI.redKey.color = redKeyColor;
        }

         if (collision.gameObject.CompareTag("Player"))
        {
            uıTweenScript.LevelComplete(); 
        }       
    }

     void EndGame()
    {
        
        SceneManager.LoadScene("Scene2"); // Oyunun sonlandığı sahneye geçiş yap
        
    }
    void Update()
    {
        angle = hinge.angle;

        motor.targetVelocity = -angle;

        if (keyUI != null && keyUI.redKey.gameObject.activeSelf)
        {
            hinge.useMotor = true;
            hinge.useLimits = true;
            hinge.useSpring = true;
            hinge.useMotor = true;
            hinge.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        hinge.motor = motor;
    }
}
