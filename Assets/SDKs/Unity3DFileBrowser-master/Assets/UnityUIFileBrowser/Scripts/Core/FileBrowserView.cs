
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;

using AsImpL;

namespace poisins.core
{

    /// <summary>
    /// Main FileBrowser script
    /// </summary>
    [DisallowMultipleComponent]
    public class FileBrowserView : MonoBehaviour
    {

        [Header("Browser window")]
        public Dropdown DriveListDropdown;
        public Text PathText;
        public ScrollRect ContentScrollrect;
        public Text SelectedFileText;
        public Button OpenFileButton;

        [Header("Disk content view")]
        public RectTransform DiskContentPlace;
        public GameObject DiskContentItemPrefab;

        public string SelectEventName { get; set; }
        public string OpenFilePath { get; set; }

        private string systemDrive;
        private string currentPath;

        private static FileBrowserView _instance;

        public static FileBrowserView Instance
        {
            get
            {
                //try to find an instance of FileBrowserWindow.prefab
                //in one of the canvases in the scene
                //and cache the reference
                if (_instance == null)
                {
                    foreach(Canvas c in FindObjectsOfType<Canvas>())
                    {
                        Component[] fbvs = c.transform.GetComponentsInChildren(typeof(FileBrowserView), true);

                        if (fbvs.Length > 0) //Found it!
                        {
                            _instance = (FileBrowserView)fbvs[0];

                            if (fbvs.Length > 1)
                                Debug.LogWarning("You have multiple file browser instances in your scene! You only need one");

                            break;
                        }
                    }
                }

                return _instance;
            }
        }

        void Awake()
        {
            systemDrive = Path.GetPathRoot(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.System));
            objImporter = gameObject.AddComponent<ObjectImporter>();
        }

        void OnEnable()
        {
            GetDriveList();
        }

        /// <summary>
        /// Free content transform for new items
        /// </summary>
        private void ClearContent(Transform contentTransform)
        {
            foreach (Transform item in contentTransform)
            {
                Destroy(item.gameObject);
            }
        }

        /// <summary>
        /// Load drive list and display in dropdown menu
        /// </summary>
        private void GetDriveList()
        {
            DriveListDropdown.ClearOptions();
            DriveListDropdown.value = -1;

            string[] logicalDrives = Directory.GetLogicalDrives();
            int cDriveIndex = 0;
            for (int i = 0; i < logicalDrives.Length; i++)
            {
                Dropdown.OptionData data = new Dropdown.OptionData(logicalDrives[i]);
                if (logicalDrives[i].Contains(systemDrive))
                    cDriveIndex = i;
                DriveListDropdown.options.Add(data);
            }
            DriveListDropdown.value = cDriveIndex;
            DriveListDropdown.onValueChanged.Invoke(DriveListDropdown.value);
        }

        /// <summary>
        /// Show current path folder text without drive letter
        /// </summary>
        private void DisplayCurrentPath(string path)
        {
            string currentDrive = DriveListDropdown.options[DriveListDropdown.value].text;
            string currentPathWithoutDrive = path.Replace(currentDrive, string.Empty);

            if (currentPathWithoutDrive.Length > 0)
                if (currentPathWithoutDrive[currentPathWithoutDrive.Length - 1] != '\\')
                    currentPathWithoutDrive += "\\";

            PathText.text = currentPathWithoutDrive;
        }

        public void DriveChanged(int dropdownIndex)
        {
            if (dropdownIndex != -1)
            {
                string drivePath = DriveListDropdown.options[dropdownIndex].text;
                ShowDirectory(drivePath);
                DriveListDropdown.captionText.text = DriveListDropdown.options[dropdownIndex].text;
            }
        }

        /// <summary>
        /// Show disk content for specified path
        /// </summary>
        /// <param name="path">Path whos content should be shown</param>
        public void ShowDirectory(string path)
        {
            currentPath = path;
            SelectedFileText.text = string.Empty;
            OpenFilePath = string.Empty;
            OpenFileButton.interactable = false;

            ClearContent(DiskContentPlace);
            Transform contentTransform = DiskContentPlace;
            try
            {
                // Get subdirectory list
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    GameObject temp = Instantiate(DiskContentItemPrefab) as GameObject;
                    temp.GetComponent<DiskContentItemScript>().SetButton(directory + @"\", false, this);
                    temp.transform.SetParent(contentTransform);
                }

                // Get file list
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    GameObject temp = Instantiate(DiskContentItemPrefab) as GameObject;
                    temp.GetComponent<DiskContentItemScript>().SetButton(file, true, this);
                    temp.transform.SetParent(contentTransform);
                }
            }
            catch { }

            DisplayCurrentPath(path);
            ContentScrollrect.verticalNormalizedPosition = 1;
        }

        /// <summary>
        /// Move one step up in folder tree
        /// </summary>
        public void PreviousFolder()
        {
            // no need to go up if current path is root directory
            if (currentPath == Path.GetPathRoot(currentPath))
                return;

            // remove ending slash if path ends with one
            // needed to get parent directory
            if (currentPath[currentPath.Length - 1] == '\\')
                currentPath = currentPath.Remove(currentPath.Length - 1, 1);

            string pervFolder = Directory.GetParent(currentPath).FullName;
            ShowDirectory(pervFolder);
        }

        /// <summary>
        /// Show root folder content
        /// </summary>
        public void OpenRootDirectory()
        {
            DriveListDropdown.value = -1;
            int rootDriveIndex = 0;
            for (int i = 0; i < DriveListDropdown.options.Count; i++)
            {
                if (DriveListDropdown.options[i].text == systemDrive)
                {
                    rootDriveIndex = i;
                    break;
                }
            }
            DriveListDropdown.value = rootDriveIndex;
        }

        /// <summary>
        /// Close file browser window. Doesn't return seleted file path
        /// </summary>
        public void CloseFileBrowser()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Open file browser window. Doesn't return seleted file path
        /// </summary>
        public void OpenFileBrowser()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Return selected file path if widow opened with <c>OpenFileBrowser(MonoBehavior)</c>
        /// and close browser window
        /// </summary>
        /// 


        public ImportOptions importOptions = new ImportOptions();
        public ObjectImporter objImporter;
        public OBJLoader objloader;

        // This calls on the obj importer once the filebrowser recognises a file being clicked
        public void OpenFileButtonClick()
        {
            if (!string.IsNullOrEmpty(OpenFilePath) && FileBrowser.BrowserCallback != null)

            FileBrowser.BrowserCallback(OpenFilePath);
            objImporter.ImportModelAsync("MyObject", OpenFilePath, null, importOptions);

        }



    }

}