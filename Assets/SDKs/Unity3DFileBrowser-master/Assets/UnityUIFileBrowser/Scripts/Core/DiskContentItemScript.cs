using UnityEngine;
using UnityEngine.UI;
using System.IO;
using AsImpL;

namespace poisins.core
{

    /// <summary>
    /// Describes items in file browser
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class DiskContentItemScript : MonoBehaviour
    {

        // Inspector fields
        [Header("Visible fields")]
        [SerializeField]
        private Image IconField;
        [SerializeField]
        private Text NameField;

        [Header("Icons")]
        [SerializeField]
        private Sprite FolderIcon;
        [SerializeField]
        private Sprite FileIcon;

        //public string Extension
        //{
        //    get
        //    {
        //        return name.Remove(0, name.LastIndexOf('.'));
        //    }
        //}

        // Private variables
        private string itemPath;
        private string itemName;
        private bool isFile;
        private FileBrowserView browserScript;

        // Methods
        public void ButtonClick()
        {
            if (!isFile)
            {
                browserScript.ShowDirectory(itemPath);
            }
            else
            {
                browserScript.SelectedFileText.text = "Selected file: " + itemName;
                browserScript.OpenFilePath = itemPath;
                browserScript.OpenFileButton.interactable = true;
            }
        }

        /// <summary>
        /// Set DiskContentItem properties
        /// </summary>
        /// <param name="path">Item path</param>
        /// <param name="isFile">Whether item is directory</param>
        /// <param name="browserScript">Reference to FileBrowserSript. Usually the one, who calls this method</param>
        public void SetButton(string path, bool isFile, FileBrowserView browserScript)
        {
            this.browserScript = browserScript;

            this.itemPath = path;
            this.isFile = isFile;
            if (isFile)
            {
                // get file name
                itemName = Path.GetFileName(path);
                IconField.sprite = FileIcon;
            }
            else
            {
                //get folder name
                itemName = Path.GetFileName(Path.GetDirectoryName(path));
                IconField.sprite = FolderIcon;
            }
            NameField.text = itemName;
            gameObject.name = itemName;
        }

        /*public ImportOptions importOptions = new ImportOptions();
        public ObjectImporter objImporter;
        public OBJLoader objloader;

        // activate objectloader 
        public void Awake()
        {
#if (UNITY_ANDROID || UNITY_IPHONE)
                _path = Application.persistentDataPath + "/" + filePath;
#endif
            objImporter = gameObject.AddComponent<ObjectImporter>();


        }
        // uploads file
        public void Start()
        {
            //if (itemPath != "")
            {
                objImporter.ImportModelAsync("My Object", itemPath, null, importOptions);
            }

        }
        */
    }

  

}
