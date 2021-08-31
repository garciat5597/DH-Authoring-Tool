using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SFB;

public class LoadModelScript : MonoBehaviour
{
    public MeshFilter outputMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fileSelect()
    {
        var extensions = new[]
        {
            new ExtensionFilter("3D Objects", "obj")
        };
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", Application.dataPath, extensions, false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutine(string url)
    {
        ObjImporter importer = new ObjImporter { };
        Debug.Log(url);
        yield return null;
        Mesh imported = importer.ImportFile(url);
        outputMesh.mesh = imported;
    }
}
