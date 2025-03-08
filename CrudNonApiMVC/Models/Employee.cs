namespace CrudNonApiMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public  string? Name { get; set; } //naay question mark kay nullable pasabot, lobot. pag dapat non nullable naay required dapat
        public  string? Department { get; set; } 
        public  string? Email { get; set; }
    }
}
