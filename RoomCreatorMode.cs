using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Core;

namespace CreatorMode
{
    public class RoomCreatorMode : MonoBehaviour
    {
        private void Update()
        {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(int.Parse(Camera.main.ScreenToWorldPoint(Input.mousePosition).x.ToString("f0")),
                                                                            int.Parse(Camera.main.ScreenToWorldPoint(Input.mousePosition).y.ToString("f0")), 200));
            RaycastHit hit;
            if (CreatorHud.actualPrefab != null)
            {
                if (Physics.Raycast(ray, out hit, 200))
                {
                    if (hit.transform.CompareTag("Scenario"))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            //TODO ROTAR y CAMBIAR A BOTON EN JUEGO
                            Instantiate(CreatorHud.actualPrefab, new Vector3(int.Parse(Camera.main.ScreenToWorldPoint(Input.mousePosition).x.ToString("f0")),
                                                                    int.Parse(Camera.main.ScreenToWorldPoint(Input.mousePosition).y.ToString("f0")), -0.2f),
                                                                    Quaternion.identity);
                        }
                    }
                    if (hit.transform.CompareTag("Item"))
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.transform.Rotate(0, 0, -90);
                        }
                        if (Input.GetKey(KeyCode.Q))
                        {
                            Destroy(hit.transform.gameObject);
                        }
                    }
                }
            }
        }

        public void SetVariant(string _type)
        {
            int ItemsCount = 0;
            CreatorHud.actualPrefab = null;
            switch (_type)
            {
                case "Ray":
                    ItemsCount = GameController.GetRayItem.Count;
                    newItem = GameController.GetRayItem;
                    break;
                case "Mirror":
                    ItemsCount = GameController.GetMirrorItem.Count;
                    newItem = GameController.GetMirrorItem;
                    break;
                case "Combine":
                    ItemsCount = GameController.GetCombineItem.Count;
                    newItem = GameController.GetCombineItem;
                    break;
                case "Wall":
                    ItemsCount = GameController.GetWallItem.Count;
                    newItem = GameController.GetWallItem;
                    break;
                case "Finish":
                    ItemsCount = GameController.GetFinishItem.Count;
                    newItem = GameController.GetFinishItem;
                    break;
            }

            for (int i = 0; i < VariantButtons.transform.childCount; i++)
            {
                try
                {
                    for (int j = 0; j < ItemsCount; j++)
                    {
                        VariantButtons.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = newItem[i].GetComponent<SpriteRenderer>().sprite;
                    }
                    VariantButtons.transform.GetChild(i).GetComponent<CreatorButtonsVariantPrefab>().ItemPrefab = newItem[i];
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex);

                    VariantButtons.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = NullItem;
                    VariantButtons.transform.GetChild(i).GetComponent<CreatorButtonsVariantPrefab>().ItemPrefab = null;
                }
            }
        }

        public void RemoveAllItems()
        {
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
            {
                Destroy(item);
            }
            
        }

        //private bool isVariantDisplay = false;
        public List<GameObject> newItem = null;

        [SerializeField] private GameObject VariantButtons = null;


        [SerializeField] private Sprite NullItem = null;
        [SerializeField] private LayerMask ScenarioMask;

        [SerializeField] private CreatorHUD CreatorHud;

        [SerializeField] private GameController GameController = null;
    }
}