using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SteganoExI : MonoBehaviour,IChanged {
	void Start(){
		HasChanged ();
	}
	#region IChanged implementation

	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

	}

	#endregion



}

namespace UnityEngine.EventSystems{
	public interface IChanged : IEventSystemHandler{
		void HasChanged();
	}
}
