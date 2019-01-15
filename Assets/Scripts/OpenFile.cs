using UnityEngine;
using SFB;
using AsImpL;
using poisins.core;
using System.IO;


public class OpenFile : MonoBehaviour
{
    
    public string filePath;
    //public string correctPath;
    public FileBrowserView filebrowserview;
     
    
   
    
    public ImportOptions importOptions = new ImportOptions();
    public ObjectImporter objImporter;
    public OBJLoader objloader;



    /* // initiating GUI
     public void OnGUI()
     {

         var guiScale = new Vector3(Screen.width / 800.0f, Screen.height / 600.0f, 1.0f);
         GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiScale);

         GUILayout.Space(20);
         GUILayout.BeginHorizontal();
         GUILayout.Space(20);
         GUILayout.BeginVertical();

         // Open Files

         if (GUILayout.Button("Open File"))
         {

             WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", true));

         }

     }

     //showing path
     public void WriteResult(string[] paths)
     {
         if (paths.Length == 0)
         {
             return;
         }

         filePath = "";

         foreach (var p in paths)
         {
             filePath += p + "\n";
         }
         correctPath = filePath.Replace("\\", "/");
     }

     // updating path name  
     public void WriteResult(string path)
     {

         correctPath = path;
     }

 */
    public void Start()
    {
        filebrowserview.ShowDirectory(filePath);

    }

    // activate objectloader 
    public void Awake()
    {
#if (UNITY_ANDROID || UNITY_IPHONE)
                _path = Application.persistentDataPath + "/" + filePath;
#endif
        objImporter = gameObject.AddComponent<ObjectImporter>();
        

    }
    // doesn't activate
     public void Update()
    {
        if (filePath != "")
        {
            Invoke(filePath, 0f);
            objImporter.ImportModelAsync("My Object", filePath, null, importOptions);
        }
        
    }


}