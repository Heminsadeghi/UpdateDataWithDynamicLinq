using System.ComponentModel.DataAnnotations;

namespace UpdateDataWithDynamicLinq.Model;

public class Student
{
    [Key]
    public int Id { set; get; }

    public string Name { set; get; }

}

