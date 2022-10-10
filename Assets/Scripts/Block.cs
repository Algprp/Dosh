using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject BlockExplosion;
    public GameObject Prefab;
    float blockCondition;
    public string collisionTag;
    
    Material blockMaterial;

    private void Start()
    {
        Prefab = this.gameObject;
        blockCondition = Random.Range(0, 10);
        blockMaterial = Prefab.GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        
        blockMaterial.color = new Color(100 / 255f * 10 / blockCondition, 40 / 255f, 80 / 255);
        if (blockCondition <= 0) { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            blockCondition -= 1;
            blockMaterial = new Material(blockMaterial);
            
        }
        if (blockCondition <= 0)
        {
            BlockExplosion.transform.position = Prefab.transform.position;
            Instantiate(BlockExplosion);
            Destroy(gameObject);
        }
    }
}
