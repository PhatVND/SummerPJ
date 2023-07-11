using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [SerializeField] private AudioSource buildSFX;
    public GameObject floatingTextPrefab_money;
    public GameObject floatingTextPrefab_dragonfrags;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
        }
        instance = this; // this is the only Build Manager
       
    }


    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            ShowFloatingText(floatingTextPrefab_money, node);
            return;
        }
        if (PlayerStats.dragonFragments < turretToBuild.dfcost) {
            ShowFloatingText(floatingTextPrefab_dragonfrags, node);
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        buildSFX.Play();

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Money left: " + PlayerStats.money);
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;



    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >=  turretToBuild.cost; } }
    public bool HasDragonFrags { get { return PlayerStats.dragonFragments >= turretToBuild.dfcost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
;

    }


    public void DeselectNode()
    {
        selectedNode = null;
    }



    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    void ShowFloatingText(GameObject floatingText, Node node)
    {
        Instantiate(floatingText, node.transform.position, Quaternion.identity);
    }
}
