// Author: Salvis Poišs (poisins92@gmail.com)
// Feel free to use and modify (and leave some credits :) )!

using UnityEngine;

namespace poisins.core
{

    /// <summary>
    /// Reset object's scale
    /// </summary>
    [DisallowMultipleComponent]
    public class ResetScale : MonoBehaviour
    {

        // Use this for initialization
        public void Start()
        {
            if (gameObject.GetComponent<RectTransform>() != null)
            {
                gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }

    }

}