using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    MeshRenderer[] Mesh;
    public GameObject scorePrefab;
    public GameObject ParticlePrefab;
    GameObject canvas;
    
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;

    void Start()
    {
        
        Mesh = this.GetComponentsInChildren<MeshRenderer>();
        canvas = GameObject.Find("Canvas");
    }
    
    public static void SonidoCoin()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/CoinPicker");
        Debug.Log("Moenda");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(10);

            SonidoCoin();
            
            GameObject scoreText = Instantiate(scorePrefab);
            //scoreText.transform.parent = canvas.transform;
            scoreText.transform.SetParent(canvas.transform);

            GameObject pE = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
            Destroy(pE, 1);

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            scoreText.transform.position = screenPoint;

            foreach (MeshRenderer m in Mesh)
            {
                m.enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        if (Mesh != null)
        {
            foreach (MeshRenderer m in Mesh)
            {
                m.enabled = true;
            }

        }
    }
}
