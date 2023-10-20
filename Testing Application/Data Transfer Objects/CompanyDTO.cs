namespace TestingApplication.Data_Transfer_Objects
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogoLink { get; set; }
        public List<JobDTO>? CurrentJobs { get; set; }
        public List<JobDTO>? ArchivedJobs { get; set; }
    }
}
