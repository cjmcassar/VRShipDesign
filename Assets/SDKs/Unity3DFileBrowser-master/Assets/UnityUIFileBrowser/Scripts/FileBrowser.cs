// Author: Nika Kasradze (kasradzenika [] yahoo [] com)

using poisins.core;

namespace poisins
{
    public static class FileBrowser
    {

        public static BrowserCallback BrowserCallback
        {
            get;
            private set;
        }

        /// <summary>
        /// Open file browser window with option to return selected file path
        /// </summary>
        /// <param name="browserCallback">MonoBehavior to process returned file path. Specify <c>this.SelectEventName</c> first!</param>
        public static void OpenFileBrowser(BrowserCallback browserCallback = null)
        {
            BrowserCallback = browserCallback;
            FileBrowserView.Instance.OpenFileBrowser();
        }
    }

    public delegate void BrowserCallback(string path);
}
