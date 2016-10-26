using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;
namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class InteractiveKeyboardBlock : MonoBehaviour
    {
             
        private VRInteractiveItem m_InteractiveItem;
		private Renderer m_Renderer;
		[SerializeField] private string blockChar;
		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material mOverMaterial;
		private static ArrayList listOne = new ArrayList(26);
        private void Awake ()
        {
			m_Renderer = GetComponent<Renderer>();
			m_InteractiveItem = GetComponent<VRInteractiveItem> ();
			if (!this.blockChar.Equals("_") && !this.blockChar.Equals("-") && !this.blockChar.Equals("*")) {
				listOne.Add (gameObject);
				print (gameObject.name);
			}
		}


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
			m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
			m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
			m_Renderer.material = mOverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
			m_Renderer.material = defaultMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
			if (this.blockChar.Equals ("-")) {
				StaticVars.passwordText = StaticVars.passwordText.Remove (StaticVars.passwordText.Length - 1);
			} else if(this.blockChar.Equals("_")){
				StaticVars.passwordText = "";
			}else if(this.blockChar.Equals("*")){
				StaticVars.reveal = !StaticVars.reveal;
			}else {
				StaticVars.passwordText += this.blockChar;
				scrambleKeyboard ();
			}
		}
		private void HandleDoubleClick(){
			Debug.Log ("Test");
			HandleClick ();
		}
		private void scrambleKeyboard(){
			foreach(GameObject g in listOne){
				Vector3 tempPos = g.transform.position;
				Quaternion tempRot = g.transform.rotation;
				int r = Random.Range (0, 25);
				g.transform.position = ((GameObject)(listOne [r])).transform.position;
				g.transform.rotation = ((GameObject)(listOne [r])).transform.rotation;
				((GameObject)(listOne [r])).transform.position = tempPos;
				((GameObject)(listOne [r])).transform.rotation = tempRot;
			}
		}
    }
}