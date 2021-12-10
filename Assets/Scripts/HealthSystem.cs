using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private List<Material> shaders;
    private bool onCooldown;

    [SerializeField] private float ShrinkTime = 1.0f; 
    [SerializeField] private float ShrinkAmount = 0.005f;
    
    [Header("Health Variables")]
    public float currentHealth;
    public float maxHealth = 0.070f;
    [SerializeField] private float minHealth = -0.010f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        foreach (Material m in GetComponent<Renderer>().materials)
        {
            shaders.Add(m);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onCooldown) return;
        StartCoroutine(ShrinkTimer());

        if (currentHealth <= minHealth)
        {
            currentHealth = minHealth;
            Debug.Log("game over");
        }
    }
    
    private IEnumerator ShrinkTimer()
    {
        onCooldown = true;
        yield return new WaitForSeconds(ShrinkTime);
        //amount = Random.Range(-0.05f,0.010f);
        currentHealth -= ShrinkAmount;

        for (int i = 0; i < shaders.Count; i++)
        {
            shaders[i].SetFloat("_Amount", currentHealth);
        }
        onCooldown = false;
    }
}
