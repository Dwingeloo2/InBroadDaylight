using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FileNames
{
	public List<string> fileString = new List<string>(); 
	public FileNames ()
	{
		string path = Directory.GetCurrentDirectory();
		path = path + @"/Assets/Resources/planetMat";
		DirectoryInfo d = new DirectoryInfo(@path);//Assuming Test is your Folder
		FileInfo[] Files = d.GetFiles("*.mat"); //Getting Text files
		foreach(FileInfo file in Files )
		{
			string fN = "planetMat/" + file.Name;
			fileString.Add(fN);
		}
	}
}