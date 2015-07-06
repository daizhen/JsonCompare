﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonCompare
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			TestJson();
		}


		private void TestJson()
		{
			string jsonStr = "{'name':'dd','array':[11,22,33],'struct':{'name2':'xxx','name3':'xxx9999'},'arrayOfArray':[[1,2,3],[4,5,6],[3]]}";
            string jsonStr2 = "{'name':'dd updated','array':[11,22,33,55],'struct':{'name2':'xxx','name3':'xxx9999'},'arrayOfArray':[[1,2],[4,5,6]]}";
			JObject jobject = JObject.Parse(jsonStr);
			JObject jobject2 = JObject.Parse(jsonStr2);

			CompareHandler handler = new CompareHandler();

			CompareStruct compareResult = handler.CompareStruct(jobject, jobject2);

            string xml = compareResult.ToXML("descriptor");
			//foreach (var childNode in jobject.Children())
			//{
			//	//JValue, JArray, JObject
			//	var property = childNode as JProperty;
			//	string name = property.Name;
			//	var value = property.Value;
			//	var node = jobject[name];

			//	Console.WriteLine("name:" + name);
			//	Console.WriteLine("value:" + value);

			//}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
