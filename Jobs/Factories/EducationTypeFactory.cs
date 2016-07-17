namespace Jobs.Factories
{
	public class EducationTypeFactory
	{
		private readonly string _educationString;

		public EducationTypeFactory(string educationString)
		{
			_educationString = educationString;
		}

		public EducationType GetEducationType()
		{
			if(_educationString == null)
				return EducationType.Unknown;

			var incompleteHigherEducation = EducationType.IncompleteHigherEducation.GetDescription();
			if(_educationString.Contains(incompleteHigherEducation))
				return EducationType.IncompleteHigherEducation;

			var incompleteSecondaryEducation = EducationType.IncompleteSecondaryEducation.GetDescription();
			if (_educationString.Contains(incompleteSecondaryEducation))
				return EducationType.IncompleteSecondaryEducation;

			var secondaryEducation = EducationType.SecondaryEducation.GetDescription();
			if (_educationString.Contains(secondaryEducation))
				return EducationType.SecondaryEducation;

			var secondarySpecialEducation = EducationType.SecondarySpecialEducation.GetDescription();
			if (_educationString.Contains(secondarySpecialEducation))
				return EducationType.SecondarySpecialEducation;

			var student = EducationType.Student.GetDescription();
			if (_educationString.Contains(student))
				return EducationType.Student;

			var higherEducation = EducationType.HigherEducation.GetDescription();
			if (_educationString.Contains(higherEducation))
				return EducationType.HigherEducation;

			var mba = EducationType.MBA.GetDescription();
			if (_educationString.Contains(mba))
				return EducationType.MBA;

			var academicDegree = EducationType.AcademicDegree.GetDescription();
			if (_educationString.Contains(academicDegree))
				return EducationType.AcademicDegree;

			return EducationType.Unknown;

		}
	}
}