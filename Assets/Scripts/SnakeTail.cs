using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeTail : MonoBehaviour
{
    public List<GameObject> Tail = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();
    public GameObject TailPrefab;
    protected int Gap = 4;
    protected float BodySpeed = 5;
    public float SnakeLength = 3;
    public string TagBlock;

    private void Start()
    {
        AddTail();
        AddTail();
        AddTail();
        
    }
    private void FixedUpdate()
    {
        SnakeLength = Tail.Count;

        PositionsHistory.Insert(0, transform.position);
        int index = 0;
        foreach (var tail in Tail)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }
        Lose();
    }
    public void AddTail()
    {
        GameObject tail = Instantiate(TailPrefab);
        Tail.Add(tail);
    }
    public void RemoveTail()
    {
        Destroy(Tail[0]);
        Tail.RemoveAt(0);
        PositionsHistory.RemoveAt(0);
    }
    void Lose()
    {
        if (SnakeLength <= 0)
        {
            Debug.Log("You Lost!");
            Destroy(gameObject);
            ReloadLevel();
        }
    }
    void OnCollisionEnter(Collision collBlock)
    {
        if (collBlock.gameObject.tag == TagBlock)
        {
            transform.Translate(new Vector3(0, 0, -0.7f));
            RemoveTail();
        }
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
