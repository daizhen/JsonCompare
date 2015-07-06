using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
	public class CompareHandler
	{
		public CompareStruct Compare(JObject originalObject, JObject newObject)
		{
			CompareStruct resultStruct = new CompareStruct();

			foreach (var childNode in originalObject.Children())
			{
				var property = childNode as JProperty;
				string name = property.Name;
				var value = property.Value;

				if (value is JValue)
				{
					resultStruct.Fields.Add(name, Compare(value as JValue, newObject[name] as JValue));
				}
				else if (value is JArray)
				{
					resultStruct.Fields.Add(name, Compare(value as JArray, newObject[name] as JArray));
				}
				else
				{
					resultStruct.Fields.Add(name, Compare(value as JObject, newObject[name] as JObject));
				}
			}
			return resultStruct;
		}

		public CompareArray Compare(JArray originalArray, JArray newArray)
		{
			CompareArray resultArray = new CompareArray();

			if (newArray == null && originalArray != null)
			{
				//Original value was deleted.

			}
			else if (originalArray == null && newArray !=null)
			{
				//New added items.
			}
			else
			{
				for (int i = 0; i < originalArray.Count; i++)
				{
					if (i >= newArray.Count)
					{
						//Original value was deleted
						if (originalArray[i] is JValue)
						{
							string originalValue = (originalArray[i] as JValue).Value.ToString();
							resultArray.Items.Add(new CompareBasic() { Type = ChangeType.Delete, OriginalValue = originalValue, NewValue = null });
						}
						else if (originalArray[i] is JArray)
						{
							resultArray.Items.Add(Compare(originalArray[i] as JArray, null));
						}
						else if (originalArray[i] is JObject)
						{
							resultArray.Items.Add(Compare(originalArray[i] as JObject, null));
						}
						else
						{
							throw new Exception("Not supported.." + originalArray[i].GetType().ToString());
						}
					}
					else
					{
						//Original value was updated
						if (originalArray[i] is JValue)
						{
							string originalValue = (originalArray[i] as JValue).Value.ToString();
							string newValue = (newArray[i] as JValue).Value.ToString();
							if (IsEqual(originalArray[i] as JValue, newArray[i] as JValue))
							{
								resultArray.Items.Add(new CompareBasic() { Type = ChangeType.None, OriginalValue = originalValue, NewValue = newValue });
							}
							else
							{
								resultArray.Items.Add(new CompareBasic() { Type = ChangeType.Update, OriginalValue = originalValue, NewValue = newValue });
							}
						}
						else if (originalArray[i] is JArray)
						{
						}
						else if (originalArray[i] is JObject)
						{
						}
						else
						{
							throw new Exception("Not supported.." + originalArray[i].GetType().ToString());
						}
					}
				}
				for (int i = originalArray.Count; i < newArray.Count; i++)
				{
					//Original value was added
					if (newArray[i] is JValue)
					{
						string newValue = (newArray[i] as JValue).Value.ToString();
						resultArray.Items.Add(new CompareBasic() { Type = ChangeType.Add, OriginalValue = null, NewValue = newValue });
					}
					else if (originalArray[i] is JArray)
					{
					}
					else if (originalArray[i] is JObject)
					{

					}
					else
					{
						throw new Exception("Not supported.." + originalArray[i].GetType().ToString());
					}
				}
			}
			return resultArray;
		}

		public CompareBasic Compare(JValue originalValue, JValue newValue)
		{
			CompareBasic compareBasic = new CompareBasic();
			if (IsEqual(originalValue, newValue))
			{
				compareBasic.Type = ChangeType.None;
			}
			else
			{
				compareBasic.Type = ChangeType.Update;
			}

			if (originalValue.Value != null)
			{
				compareBasic.OriginalValue = originalValue.Value.ToString();
			}
			else
			{
				compareBasic.OriginalValue = string.Empty;
			}

			if (newValue.Value != null)
			{
				compareBasic.NewValue = newValue.Value.ToString();
			}
			else
			{
				compareBasic.NewValue = string.Empty;
			}

			return compareBasic;
		}

		private bool IsEqual(JValue originalValue, JValue newValue)
		{
			if (originalValue.Value == null && newValue.Value == null)
			{
				return true;
			}

			if (originalValue.Value != null)
			{
				if (newValue.Value == null)
				{
					return false;
				}
				else
				{
					return originalValue.Value.Equals(newValue.Value);
				}
			}
			return false;
		}
	}
}
