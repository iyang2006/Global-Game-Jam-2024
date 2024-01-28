using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] public int maximumHealth;
    //[SerializeField] private GameObject healthText;
    //private TextMeshProUGUI healthBar;
    [SerializeField] private GameObject healthBar;
    private Slider healthSlider;
    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        healthSlider = healthBar.GetComponent<Slider>();
        setSlider();
        /*healthBar = healthText.GetComponent<TextMeshProUGUI>();
        if (healthBar != null )
        {
            healthBar.text = "" + currentHealth;
        }*/
    }



    /// <summary>
    /// Deals the specified amount of damage to the entity owning this health script.
    /// This method enforces the minimum health value of zero.
    /// </summary>
    /// <param name="damage">
    /// The amount of damage to deal to this entity
    /// </param>
    /// <returns>
    /// The actual amount of damage dealt
    /// </returns>
    public float damageEntity(float damage)
    {
        float damageDealt = (currentHealth - damage <= 0f) ? currentHealth : damage;
        currentHealth -= damageDealt;
        if (currentHealth <= 0f)
        {
            kill();
        }
        setSlider();
        /*if (healthBar != null)
        {
            healthBar.text = "" + currentHealth;
        }*/
        return damageDealt;
    }



    /// <summary>
    /// Destroys the entity owning this health script.
    /// </summary>
    public void kill()
    {
        Destroy(gameObject);
    }



    /// <summary>
    /// Provides the specified amount of healing to the entity owning this health script.
    /// This method enforces the maximum health value of the entity.
    /// </summary>
    /// <param name="healing">
    /// The amount of healing to provide to this entity
    /// </param>
    /// <returns>
    /// The actual amount of healing provided
    /// </returns>
    public float healEntity(float healing)
    {
        float healingDealt = (currentHealth + healing >= maximumHealth) ? maximumHealth - currentHealth : healing;
        currentHealth += healingDealt;
        setSlider();
        /*if (healthBar != null)
        {
            healthBar.text = "" + currentHealth;
        }*/
        return healingDealt;
    }



    // Update is called once per frame
    void Update()
    {

    }

    void setSlider()
    {
        if (healthSlider != null) {
            healthSlider.value = currentHealth / maximumHealth;
        }
    }
}

