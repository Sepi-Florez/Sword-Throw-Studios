using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public int schakel;
	public enum Kip {kip0, kip1, kip2};
	public Kip kippetje;
	void Start () {
		switch (kippetje){
			case Kip.kip0:
			print("0 kip");
			break;
		
			case Kip.kip1:
			print("1 kip");
			break;
			
			case Kip.kip2:
			print("2 kip");
			break;
		}
	}
	
	void Update () {
	
	}
}
