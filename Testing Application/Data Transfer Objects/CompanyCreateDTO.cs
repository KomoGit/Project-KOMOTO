namespace TestingApplication.Data_Transfer_Objects
{
    public class CompanyCreateDTO
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }

        public IFormFile CompanyLogo { get; set; }
    }
}
