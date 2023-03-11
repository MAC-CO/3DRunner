using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    MeshRenderer[] Mesh;
    public GameObject scorePrefab;
    public GameObject ParticlePrefab;
    GameObject canvas;

    void Start()
    {
        Mesh = this.GetComponentsInChildren<MeshRenderer>();
        canvas = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(10);
            PlayerController.sfx[1].Play();
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
