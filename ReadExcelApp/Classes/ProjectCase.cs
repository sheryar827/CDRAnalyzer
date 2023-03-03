namespace ReadExcelApp
{
    class ProjectCase
    {
        public int project_ID { get; set; }
        public string projectName { get; set; }

        public ProjectCase(int project_ID, string projectName)
        {
            this.project_ID = project_ID;
            this.projectName = projectName;
        }
    }
}
