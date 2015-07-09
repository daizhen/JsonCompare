using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompareLib
{
	public class CompareHandler
	{


        private object Compare(object originalValue, object newValue)
        {
            object temObject = null;

            if (originalValue != null)
            {
                temObject = originalValue;
            }
            else if (newValue != null)
            {
                temObject = newValue;
            }

            if(temObject == null)
            {
                throw new Exception("Both values are null");
            }

            if (temObject.GetType() == typeof(JObject))
            {
                return CompareStruct(originalValue as JObject, newValue as JObject);
            }
            if (temObject.GetType() == typeof(JArray))
            {
                return CompareArray(originalValue as JArray, newValue as JArray);
            }
            if (temObject.GetType() == typeof(JValue))
            {
                return CompareBasic(originalValue as JValue, newValue as JValue);
            }

            throw new Exception("Not supported type");
        }


		public CompareStruct CompareStruct(JObject originalObject, JObject newObject)
		{
			CompareStruct resultStruct = new CompareStruct();

			foreach (var childNode in originalObject.Children())
			{
				var property = childNode as JProperty;
				string name = property.Name;
				var value = property.Value;
                resultStruct.Fields.Add(name, Compare(value, newObject[name]));
			}
			return resultStruct;
		}

		public CompareArray CompareArray(JArray originalArray, JArray newArray)
		{
			CompareArray resultArray = new CompareArray();

            if (newArray == null && originalArray == null)
            {
                throw new Exception("Both values are null..");
            }

			if (newArray == null && originalArray != null)
			{
				//Original value was deleted.
                foreach (JToken item in originalArray)
                {
                    resultArray.Items.Add(Compare(item, null));
                }
			}
			else if (originalArray == null && newArray !=null)
			{
				//New added items.
                foreach (JToken item in newArray)
                {
                    resultArray.Items.Add(Compare(null, item));
                }
			}
			else
			{
				for (int i = 0; i < originalArray.Count; i++)
				{
					if (i >= newArray.Count)
					{
						//Original value was deleted
                        resultArray.Items.Add(Compare(originalArray[i], null));
					}
					else
					{
						//Original value was updated
                        resultArray.Items.Add(Compare(originalArray[i], newArray[i]));
					}
				}
				for (int i = originalArray.Count; i < newArray.Count; i++)
				{
					//Original value was added
                    resultArray.Items.Add(Compare(null, newArray[i]));
				}
			}
			return resultArray;
		}

		public CompareBasic CompareBasic(JValue originalValue, JValue newValue)
		{
			CompareBasic compareBasic = new CompareBasic();

            if (originalValue == null && newValue != null)
            {
                compareBasic.Type = ChangeType.Add;
            }
            else if (originalValue != null && newValue == null)
            {
                compareBasic.Type = ChangeType.Delete;
            }
            else
            {
                if (IsEqual(originalValue, newValue))
                {
                    compareBasic.Type = ChangeType.None;
                }
                else
                {
                    compareBasic.Type = ChangeType.Update;
                }
            }

            if (originalValue !=null && originalValue.Value != null)
			{
				compareBasic.OriginalValue = originalValue.Value.ToString();
			}
			else
			{
				compareBasic.OriginalValue = string.Empty;
			}

            if (newValue != null && newValue.Value != null)
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

			if (originalValue!=null &&  originalValue.Value != null)
			{
                if (newValue == null || newValue.Value == null)
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
