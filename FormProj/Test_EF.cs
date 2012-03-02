using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace FormProj
{
	public class Student
	{
		public string Nom;
		public string Prenom;
	}

	public partial class StudentEntities : DbContext
	{
		public StudentEntities()
		{ }

		public DbSet<Student> Students { get; set; }

	}

	public class Test_EF
	{
		public Test_EF()
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<StudentEntities>());

			using (var context = new StudentEntities()) {
			}
		}
	}
}