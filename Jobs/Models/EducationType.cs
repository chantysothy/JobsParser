using System.ComponentModel;

namespace Jobs.Models
{
	public enum EducationType
	{
		[Description("Не определено")]
		Unknown,

		[Description("высшее образование")]
		HigherEducation,

		[Description("среднее специальное образование")]
		SecondarySpecialEducation,

		[Description("неоконченное высшее образование")]
		IncompleteHigherEducation,

		[Description("среднее образование")]
		SecondaryEducation,

		[Description("студент")]
		Student,

		[Description("неполное среднее образование")]
		IncompleteSecondaryEducation,

		[Description("ученая степень")]
		AcademicDegree,

		[Description("MBA")]
		Mba
	}
}
