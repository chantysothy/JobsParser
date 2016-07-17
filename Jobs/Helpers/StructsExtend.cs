using System;
using System.ComponentModel;

namespace Jobs.Helpers
{
	public static class StructsExtend
	{
		public static string GetDescription<T>(this T field) where T : struct
		{
			var type = field.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("EnumerationValue must be of Enum type", nameof(field));
			}

			//Tries to find a DescriptionAttribute for a potential friendly name
			//for the enum
			var memberInfo = type.GetMember(field.ToString());

			//If we have no description attribute, just return the ToString of the enum
			if (memberInfo.Length <= 0)
				return field.ToString();

			var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attrs.Length > 0
				? ((DescriptionAttribute) attrs[0]).Description
				: field.ToString();
		}
	}
}
