using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopButtonPrefab;
    public GameObject shopButtonCont;

    public Material playerMaterial;

    public TextMesh currencyText;
    private int[] costs = { 0, 50, 50, 50, 150, 
                                150, 150, 150, 
                            150, 150, 150, 150,
                            150, 150, 150,250 };

    private void Start()
    {

        currencyText.text = "Money:" + GameManager.Instance.currency.ToString();

        ChangePlayerSkin(GameManager.Instance.currentSkinIndex);

        int textureIndex = 0;

        Sprite[] textures = Resources.LoadAll<Sprite>("Sprites");

        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonCont.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));
            container.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = costs[index].ToString();
            
            if ((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
            {
                container.transform.GetChild(0).gameObject.SetActive(false);
            }
            textureIndex++;
        }




    }

    private void ChangePlayerSkin(int index)
    {

        if ((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
        {
            float x = (index % 4) * 0.25f;
            float y = ((int)index / 4) * 0.25f;

            if (y == 0.0f)
            {
                y = 0.75f;
            }
            else if (y == 0.25f)
            {
                y = 0.5f;

            }
            else if (y == 0.50f)
            {
                y = 0.25f;

            }
            else if (y == 0.75f)
            {
                y = 0f;

            }

            playerMaterial.SetTextureOffset("_BaseMap", new Vector2(x, y));
            GameManager.Instance.currentSkinIndex = index;
            GameManager.Instance.Save();

        }
        else
        {

            int cost = costs[index];
            Debug.Log(cost);

            if(GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.skinAvailability += 1 << index;
                GameManager.Instance.Save();
                shopButtonCont.transform.GetChild(index).GetChild(0).gameObject.SetActive(false);
                currencyText.text = "Money:" + GameManager.Instance.currency.ToString();
                ChangePlayerSkin(index);
            }

        }
    }
    
}
