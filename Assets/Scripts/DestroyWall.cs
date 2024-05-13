using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject[] bricks;
    List<Rigidbody> bricksRB = new List<Rigidbody>();
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();

    public GameObject Explosion;

    Collider Col;
    
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;
    
    public void SonidoExplosion()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Explosion");
        Debug.Log("Explosion");
    }

    private void Awake()
    {
        Col = this.GetComponent<Collider>();
        foreach (GameObject b in bricks)
        {
            bricksRB.Add(b.GetComponent<Rigidbody>());
            positions.Add(b.transform.localPosition);
            rotations.Add(b.transform.localRotation);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Spell")
        {
            GameObject Obj = Instantiate(Explosion, other.contacts[0].point, Quaternion.identity);
            Destroy(Obj, 2.5f);
            Col.enabled = false;
            foreach (Rigidbody r in bricksRB)
            {
                r.isKinematic = false;
            }
            
            SonidoExplosion();
            //PlayerController.sfx[5].Play();
        }
    }

    private void OnEnable()
    {
        Col.enabled = true;
        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].transform.localPosition = positions[i];
            bricks[i].transform.localRotation = rotations[i];
            bricksRB[i].isKinematic = true;
        }
    }
}
