using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SwitchFoot : MonoBehaviour
{
    public Button button;
    private GameObject footModel;
    private string meshName;
    
    // Start is called before the first frame update
    void Start()
    {
    	footModel = GameObject.Find("FootModel");
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SwitchBetweenFeet);
    }
    
    void SwitchBetweenFeet(){
    	MeshFilter mesh = footModel.GetComponent<MeshFilter>();
    	meshName = mesh.mesh.name;
    	Debug.Log(meshName);
    	meshName = meshName.Substring(0, meshName.Length - 9);
    	bool leftFoot;
    	if (meshName.EndsWith("left")) {
            leftFoot = true;
            meshName = meshName.Substring(0, meshName.Length - 4);
        }
    	else {
    	    leftFoot = false;
    	    meshName = meshName.Substring(0, meshName.Length - 5);
    	}
    	string path = "Assets/Models/" + meshName;
    	if (leftFoot) path += "right.fbx";
    	else path += "left.fbx";
    	Mesh newMesh = (Mesh)AssetDatabase.LoadAssetAtPath(path, typeof(Mesh));
    	newMesh.RecalculateNormals();
    	newMesh.RecalculateTangents();
    	newMesh.RecalculateBounds();
    	DestroyImmediate(footModel.GetComponent<MeshFilter>());
    	MeshFilter newFilter = footModel.AddComponent<MeshFilter>();
    	newFilter.mesh = newMesh;
    	Debug.Log(newFilter.mesh.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
