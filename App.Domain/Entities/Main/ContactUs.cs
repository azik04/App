using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities.Main;

public class ContactUs
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
}
